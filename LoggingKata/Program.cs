using System;
using GeoCoordinatePortable;
using Geolocation;
using System.Linq;
using System.IO;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        static readonly string filePath = Environment.CurrentDirectory + "/" + csvPath;

        static void Main(string[] args)
        {
            logger.SetLogLevel(TacoLogger.info);
            logger.LogInfo(Globals.logMessageInitialized);
            logger.LogInfo(Globals.logMessageReadingFileFrom + filePath);
            try
            {
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
                findFurtherestTacoBells(lines);
            }
            catch (Exception ex)
            {
                logger.LogFatal("Exception occurred reading file", ex);
                return;
            }
        }
        private static void findFurtherestTacoBells(string[] lines)
        {
            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));

            ITrackable locAMax = null;
            ITrackable locBMax = null;
            var distanceBetween = 0.0;
            var distanceBetweenMax = 0.0;
            foreach (var locA in locations)
            {
                var origin = new GeoCoordinate()
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };
                foreach (var locB in locations)
                {
                    var destination = new GeoCoordinate()
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };
                    //distanceBetween = GeoCalculator.GetDistance(origin, destination, 1);
                    distanceBetween = origin.GetDistanceTo(destination) * Globals.milesPerMeter;
                    if (distanceBetween > distanceBetweenMax)
                    {
                        distanceBetweenMax = distanceBetween;
                        locAMax = locA;
                        locBMax = locB;
                    }
                }
            }
            var distanceBetweenMaxFormatted = String.Format("{0:0.# miles}",distanceBetweenMax);
            logger.LogInfo("Max Distance Between Taco Bells is " + distanceBetweenMaxFormatted + ". Occurring between " + locAMax.Name.Substring(0, locAMax.Name.IndexOf("(")) + " and " + locBMax.Name.Substring(0, locBMax.Name.IndexOf("(")));
        }
    }
}