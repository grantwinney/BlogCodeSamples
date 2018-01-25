using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace ISS_Notify_Wrapper
{
    public static class ISS
    {
        /// <summary>
        /// Calls the ISS Notify API for the specified resource and querystring.
        /// </summary>
        /// <returns>The API.</returns>
        /// <param name="description">Description of the resource being requested</param>
        /// <param name="resource">Resource being requested</param>
        /// <param name="parameters">Parameters for the resource</param>
        /// <typeparam name="T">The type of object being requested</typeparam>
        private static T GetResource<T>(string description, string resource, Tuple<string,string>[] parameters = null) where T : new()
        {
            var client = new RestClient { BaseUrl = new Uri("http://api.open-notify.org") };

            var request = new RestRequest(resource, Method.GET);

            if (parameters != null)
                foreach (var param in parameters)
                    request.AddParameter(param.Item1, param.Item2);

            var response = client.Execute<T>(request);
            var content = response.Content;

            if (response.ErrorException != null)
                throw new ApplicationException($"Unable to retrieve {description}.", response.ErrorException);

            return response.Data;
        }

        public static void ShowRoster()
        {
            var roster = GetResource<Roster>("roster", "astros.json");

            var astronautNames = String.Join(", ", roster.People.Select(x => x.Name));
          
            Console.WriteLine($"There are {roster.Number} people in space: {astronautNames}");
        }

        public static void ShowUpcomingPasses(string latitude, string longitude)
        {
            var nextPass = GetResource<Passes>("next pass", "iss-pass.json",
                new[] { Tuple.Create("lat", latitude), Tuple.Create("lon", longitude) }).Response[0];

            Console.WriteLine($"The next ISS pass for {latitude} {longitude} is " +
                              $"{DateTimeOffset.FromUnixTimeSeconds(nextPass.Risetime)} " +
                              $"for {nextPass.Duration} seconds.");
        }

        public static void ShowCurrentLocation()
        {
            var pos = GetResource<Position>("next pass", "iss-now.json").IssPosition;

            Console.WriteLine($"The current position is: {pos.Latitude} {pos.Longitude}");
        }
    }

    public class Roster
    {
        public int Number { get; set; }
        public List<Astronaut> People { get; set; }
    }

    public class Astronaut
    {
        public string Name { get; set; }
        public string Craft { get; set; }
    }

    public class Passes
    {
        public string Message { get; set; }
        public Request Request { get; set; }
        public List<Pass> Response { get; set; }
    }

    public class Request
    {
        public int Altitude { get; set; }
        public int Datetime { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Passes { get; set; }
    }

    public class Pass
    {
        public int Duration { get; set; }
        public int Risetime { get; set; }
    }

    public class Position
    {
        public Coordinate IssPosition { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
    }

    public class Coordinate
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
