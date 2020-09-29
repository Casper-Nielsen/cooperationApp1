using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace cooperationApp1
{
    class Trip
    {
        public Location Startlocation { get; set; }
        public Location Endlocation { get; set; }
        public double Distance { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }

        public int BreakCount { get; set; }
        public double AvgBreak { get; set; }
        public double AvgSpeed { get; set; } // km/s
    }
}