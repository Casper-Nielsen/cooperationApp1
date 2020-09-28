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

namespace cooperationApp1
{
    [Service]
    public class DemoService : Service
    {
        private readonly string CHANNEL_ID = "location_notification";
        internal static readonly string COUNT_KEY = "count";
        private static int count;
        private bool run = true;
        private Trip trip = new Trip();
        private double cdistance;
        private bool moving = false;
        private double speed;
        private Task task;
        private int buffer = 0;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (intent.Action == Constants.ACTION_STOP_SERVICE)
            {
                run = false;
                StopForeground(true);
                StopSelf();
            }
            else
            {
                RegisterForegroundService();
                CreateNotificationChannel();
                //starts the measuring loop
                task = RunAsync();
            }
            return StartCommandResult.Sticky;
        }

        async Task RunAsync()
        {
            //gets high accuracy
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            while (run)
            {
                try
                {
                    //gets the current location 
                    Location location = await Geolocation.GetLocationAsync(request);
                    if (trip.Endlocation != null)
                    {
                        //gets the distance between 2 points 
                        cdistance = Location.CalculateDistance(trip.Endlocation, location, DistanceUnits.Kilometers);
                        // gets the speed in km/h
                        speed = cdistance * (3600 / (location.Timestamp.Subtract(trip.Endlocation.Timestamp).TotalSeconds));
                    }
                    trip.Endlocation = location;

                    //Debug:: shows the speed
                    Console.WriteLine("speed: " + speed);


                    if (moving)
                    {
                        if (location != null)
                        {
                            if (trip.Endlocation != null)
                            {
                                //adds to total distance
                                trip.Distance += cdistance;
                                count++;
                                //sets avgspeed
                                trip.Avgspeed += (double)(speed - trip.Avgspeed) / count;
                            }
                            if (trip.Startlocation == null)
                            {
                                //sets the start location 
                                trip.Startlocation = trip.Endlocation;
                            }
                            //if it is standing still
                            if (location.Speed < 1)
                            {
                                buffer++;
                                //buffer for (traffic light)
                                if (buffer > 30)
                                {
                                    //stops the trip measuring
                                    moving = false;
                                    trip.Endtime = DateTime.Now;

                                    //TEMP :: for sending
                                    string jsonString = JsonConvert.SerializeObject(trip);
                                }
                                //POWERSAVE :: waits 1 sec
                                Thread.Sleep(1000);
                            }
                            else if (buffer > 0)
                            {
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
                            trip = new Trip();
                            trip.Starttime = DateTime.Now;
                        }
                        else
                        {
                            //POWERSAVE :: waits 10 sec
                            Thread.Sleep(10000);
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