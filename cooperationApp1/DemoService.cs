using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Google.Protobuf.WellKnownTypes;
using System.Collections;

namespace cooperationApp1
{
    [Service]
    public class DemoService : Service
    {
        private readonly string CHANNEL_ID = "location_notification";
        private Location startlocation;
        public Location endlocation;
        public static bool running = false;
        private static int count;
        private Protobuf.Trip trip = new Protobuf.Trip();
        private double cdistance;
        private bool moving = false;
        private double speed;
        private int userId;
        private Stack tripStack;
        private int buffer = 0;
        private int noConnectionBuffer = 0;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            tripStack = new Stack();
            if (intent.Action == Constants.ACTION_STOP_SERVICE)
            {
                running = false;
                StopForeground(true);
                StopSelf();
            }
            else if (int.TryParse(intent.Action, out userId))
            {
                trip.UserId = userId;
                RegisterForegroundService();
                CreateNotificationChannel();
                //starts the measuring loop
                running = true;
                Task.Run(RunAsync);
            }
            return StartCommandResult.Sticky;
        }

        async Task RunAsync()
        {
            //gets high accuracy
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            while (running)
            {
                Console.WriteLine();
                try
                {
                    //gets the current location 
                    Location location = await Geolocation.GetLocationAsync(request);
                    if (endlocation != null)
                    {
                        //gets the distance between 2 points 
                        cdistance = Location.CalculateDistance(endlocation, location, DistanceUnits.Kilometers);
                        // gets the speed in km/h
                        speed = cdistance * (3600 / (location.Timestamp.Subtract(endlocation.Timestamp).TotalSeconds));
                    }
                    endlocation = location;

                    if (moving)
                    {
                        //adds to total distance
                        trip.Distance += cdistance;
                        count++;
                        //sets avgspeed
                        trip.AvgSpeed += (double)(speed - trip.AvgSpeed) / count;

                        if (startlocation == null)
                        {
                            //sets the start location 
                            startlocation = endlocation;
                        }
                        //if it is standing still
                        if (location.Speed < 5)
                        {
                            buffer++;
                            //buffer for (traffic light)
                            if (buffer > 30)
                            {
                                //stops the trip measuring
                                moving = false;
                                trip.Endtime = new Timestamp();
                                trip.StartLocationFormated.AddRange(new double[2] { startlocation.Latitude, startlocation.Longitude });
                                trip.EndLocationFormated.AddRange(new double[2] { endlocation.Latitude, endlocation.Longitude });
                                tripStack.Push(trip);

                            }
                            //POWERSAVE :: waits 1 sec
                            Thread.Sleep(1000);
                        }
                        else if (buffer > 0)
                        {
                            trip.BreakCount++;
                            trip.AvgBreak = (double)(buffer - trip.AvgBreak) / trip.BreakCount;
                            buffer = 0;
                            //POWERSAVE :: waits 0.1 sec
                            Thread.Sleep(100);
                        }
                        else
                        {
                            //POWERSAVE :: waits 0.2 sec
                            Thread.Sleep(200);
                        }
                    }
                    else
                    {
                        //looks if it is moving with a speed over 15km/h
                        if (speed * 3.6 > 15)
                        {
                            //starts the trip measuring 
                            moving = true;

                            //resets the values
                            speed = 0;
                            count = 0;
                            trip = new Protobuf.Trip();
                            trip.Starttime = new Timestamp();
                        }
                        else
                        {
                            if (tripStack.Count > 0 && noConnectionBuffer <= 0)
                           {
                                bool response = false;
                                if (false)
                                {
                                    if (bool.TryParse(await ApiController.PostProductAsync((Protobuf.Trip)tripStack.Peek()), out response) && response)
                                    {
                                        tripStack.Pop();
                                    }
                                }
                                else
                                {
                                    noConnectionBuffer = 10;
                                }
                            }
                            else if (noConnectionBuffer > 0)
                            {
                                noConnectionBuffer--;
                            }
                            //POWERSAVE :: waits 60 sec
                            Thread.Sleep(60000);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        void CreateNotificationChannel()
        {
            var name = "hello world";
            var description = "this is a hello world from service";
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }


        void RegisterForegroundService()
        {
            var notification = new Notification.Builder(this, CHANNEL_ID)
                              .SetContentTitle("Co2opreation") // Set the title
                              .SetNumber(count) // Display the count in the Content Info
                              .SetSmallIcon(Resource.Drawable.logo_icon) // This is the icon to display
                              .SetContentText($"vi måler dit co2 forbrug") // the message to display.
                              .SetOngoing(true)
                              .AddAction(BuildStopServiceAction())
                              .Build();


            // Enlist this instance of the service as a foreground service
            StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notification);
        }

        Notification.Action BuildStopServiceAction()
        {
            var stopServiceIntent = new Intent(this, GetType());
            stopServiceIntent.SetAction(Constants.ACTION_STOP_SERVICE);
            var stopServicePendingIntent = PendingIntent.GetService(this, 0, stopServiceIntent, 0);

            var builder = new Notification.Action.Builder(Android.Resource.Drawable.IcMediaPause,
                                                          "stop",
                                                          stopServicePendingIntent);
            return builder.Build();

        }
    }
}