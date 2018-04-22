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
            Coordinate point1A = new Coordinate();
            Coordinate point1B = new Coordinate();
            point1A.Latitude = 32.00;
            point1A.Longitude = -85.00;
            point1B.Latitude = 32.50;
            point1B.Longitude = -85.50;
            return GeoCalculator.GetDistance(point1A, point1B, 1);
        }
        public static double geoCoordinatePortable()
        {
            // GEOLOCATION PORTABLE CODE SAMPLE
            GeoCoordinate point2A = new GeoCoordinate(32.00, -85.00);
            GeoCoordinate point2B = new GeoCoordinate(32.50, -85.50);
            // In METERS multiply by .00062137 miles/meter
            return point2A.GetDistanceTo(point2B) * 0.00062137;
        }
    }

}