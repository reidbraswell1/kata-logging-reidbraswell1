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
            if(string.IsNullOrEmpty(line))
            {
                return null;
            }
            var cells = line.Split(Globals.splitChar);
            if (cells.Length < Globals.minCells)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + Globals.logMessageLength + line, new Exception ("Line too short"));
                return null;
            }
            try
            {
                var longitude = double.Parse(cells[0]);
                var latitude = double.Parse(cells[1]);
                if (Math.Abs(longitude) > Point.maxLongitude)
                {
                    throw new ArgumentOutOfRangeException(Globals.argumentExceptionLongitude);
                }
                if (Math.Abs(latitude) > Point.maxLatitude)
                {
                    throw new ArgumentOutOfRangeException(Globals.argumentExceptionLatitude);
                }
                var name = (cells.Length > Globals.minCells) ? cells[2] : null;
                var point = new Point { Latitude = latitude, Longitude = longitude };
                var tacoBell = new TacoBell { Location = point, Name = name.Replace("\"","") };
                return tacoBell;
            }
            catch (Exception e)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + e.Message + line,e);
                return null;
            }
        }
    }
}
