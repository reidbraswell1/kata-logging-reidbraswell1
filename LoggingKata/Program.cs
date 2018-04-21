using System;
using GeoCoordinatePortable;
using System.Linq;
using System.IO;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        static readonly string path = Environment.CurrentDirectory + csvPath;

        static void Main(string[] args)
        {
            logger.LogInfo(Globals.logMessageInitialized);
            logger.LogInfo(Globals.logMessageReadingFileFrom + path);

            var lines = File.ReadAllLines(Environment.CurrentDirectory + csvPath);

            // Log Error if no lines read
            if (lines.Length == 0)
            {
                logger.LogError(Globals.logMessageNoLines + path);
                return;
            }
            // Log Warning if only 1 line
            if (lines.Length == 1)
            {
                logger.LogWarning(Globals.logMessageOneLine + path);
            }

            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));

        // GEOLOCATION CODE SAMPLE 
            GeoCoordinate pin1 = new GeoCoordinate(-85, 34);
            GeoCoordinate pin2 = new GeoCoordinate(-83, 34);
            double distanceBetween = pin1.GetDistanceTo(pin2);


            var longitude = 0.0;
            var latitude = 0.0;
            foreach (var location in locations)
            {
                longitude = location.Location.Longitude;
            }
            // TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}