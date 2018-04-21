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
            logger.LogInfo(Globals.logMessageBeginParsing);
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + Globals.logMessageLength + line);
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
            }
            catch (Exception e)
            {
                logger.LogError(Globals.logMessageUnableToParseLine + e.Message + line);
                return null;
            }
            var tacoBell = new TacoBell();
            var point = new Point();
            point.Longitude = longitude;
            point.Latitude = latitude;
            tacoBell.Location = point;
            tacoBell.Name = name;
            return tacoBell;
        }
    }
}