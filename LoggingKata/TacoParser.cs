using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogDebug(Globals.logMessageBeginParsing + line);
            var cells = line.Split(Globals.splitChar);
            if (cells.Length < 3)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + Globals.logMessageLength + line, new Exception ("Line too short"));
                return null;
            }
            var longitude = 0.0;
            var latitude = 0.0;
            var name = "";
            try
            {
                longitude = double.Parse(cells[0]);
                latitude = double.Parse(cells[1]);
                name = cells[2];
                if (longitude > Globals.maxLongitude || longitude < Globals.minLongitude)
                {
                    throw new ArgumentOutOfRangeException(Globals.argumentExceptionLongitude);
                }
                if (latitude > Globals.maxLatitude || latitude < Globals.minLatitude)
                {
                    throw new ArgumentOutOfRangeException(Globals.argumentExceptionLatitude);
                }
            }
            catch (Exception e)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + e.Message + line,e);
                return null;
            }
            var tacoBell = new TacoBell();
            var point = new Point();
            point.Longitude = longitude;
            point.Latitude = latitude;
            tacoBell.Location = point;
            tacoBell.Name = name.Replace("\"","");
            return tacoBell;
        }
    }
}