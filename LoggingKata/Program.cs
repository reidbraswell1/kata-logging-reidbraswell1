using System;
using GeoCoordinatePortable;
using Geolocation;
using System.Linq;
using System.IO;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        static readonly string filePath = Environment.CurrentDirectory + "/" + csvPath;

        static void Main(string[] args)
        {
            logger.LogInfo(Globals.logMessageInitialized);
            logger.LogInfo(Globals.logMessageReadingFileFrom + filePath);

            var lines = File.ReadAllLines(filePath);

            // Log Error if no lines read
            if (lines.Length == 0)
            {
                logger.LogError(Globals.logMessageNoLines + filePath);
                return;
            }
            // Log Warning if only 1 line
            if (lines.Length == 1)
            {
                logger.LogWarning(Globals.logMessageOneLine + filePath);
            }

            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));

            // GEOLOCATION CODE SAMPLE
            Coordinate point1A = new Coordinate();
            Coordinate point1B = new Coordinate();
            point1A.Latitude = 32.00;
            point1A.Longitude = -85.00;
            point1B.Latitude = 32.50;
            point1B.Longitude = -85.50;
            double dis1 = GeoCalculator.GetDistance(point1A, point1B, 1);
            // GEOLOCATION PORTABLE CODE SAMPLE
            GeoCoordinate point2A = new GeoCoordinate(32.00, -85.00);
            GeoCoordinate point2B = new GeoCoordinate(32.50, -85.50);
            // In METERS
            double dis2 = point2A.GetDistanceTo(point2B) * 0.00062137;


            ITrackable locAMax = null;
            ITrackable locBMax = null;
            var distanceBetween = 0.0;
            var distanceBetweenMax = 0.0;
            foreach (var locA in locations)
            {
                var origin = new Coordinate();
                origin.Latitude = locA.Location.Latitude;
                origin.Longitude = locA.Location.Longitude;
                foreach (var locB in locations)
                {
                    var destination = new Coordinate();
                    origin.Latitude = locB.Location.Latitude;
                    origin.Longitude = locB.Location.Longitude;
                    distanceBetween = GeoCalculator.GetDistance(origin, destination, 1);
                    if (distanceBetween > distanceBetweenMax)
                    {
                        distanceBetweenMax = distanceBetween;
                        locAMax = locA;
                        locBMax = locB;
                    }
                }
            }
            logger.LogInfo("Max Distance Between Taco Bells is " + distanceBetweenMax.ToString() + " Occurring between " + locAMax.Name + " and " + locBMax.Name);
        }
    }
}