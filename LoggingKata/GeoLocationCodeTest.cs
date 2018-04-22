using System;
using GeoCoordinatePortable;
using Geolocation;

namespace LoggingKata
{
    public class GeoLocationCodeTest
    {
        public static double geoLocation()
        {
            // GEOLOCATION CODE SAMPLE
            var point1A = new Coordinate()
            {
                Latitude = 32.00,
                Longitude = -85.00
            };
            var point1B = new Coordinate()
            {
                Latitude = 32.50,
                Longitude = -85.50
            };
            return GeoCalculator.GetDistance(point1A, point1B, 1);
        }
        public static double geoCoordinatePortable()
        {
            // GEOLOCATION PORTABLE CODE SAMPLE
            GeoCoordinate point2A = new GeoCoordinate()
            {
                Latitude = 32.00,
                Longitude = -85.00
            };
            GeoCoordinate point2B = new GeoCoordinate()
            {
                Latitude = 32.50,
                Longitude = -85.50
            };
            // In METERS multiply by .00062137 miles/meter
            return point2A.GetDistanceTo(point2B) * 0.00062137;
        }
    }
}