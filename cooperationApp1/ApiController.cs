using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Google.Protobuf;
using cooperationApp1.Protobuf;

namespace cooperationApp1
{
    class ApiController
    {
        /// <summary>
        /// sends a get with the trip data to the server
        /// </summary>
        /// <returns>true false from the server</returns>
        static public async Task<string> GetProductAsync(Protobuf.Trip trip)
        {
            HttpClient client = new HttpClient();
            //sends to the server
            client.BaseAddress = new Uri("http://172.16.21.44/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(
                "api/MobilClient/TripViaProtobuf/?data=" + Convert.ToBase64String(trip.ToByteArray()));
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return await response.Content.ReadAsStringAsync();
        }
    }
}