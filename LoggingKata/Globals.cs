namespace LoggingKata
{
    public static class Globals
    {
        public const string logMessageBeginParsing = "Begin Parsing ";
        public const string logMessageInitialized = "Log initialized";
        public const string logMessageReadingFileFrom = "Reading csv file ";
        public const string logMessageNoLines = "Error no lines read from file ";
        public const string logMessageOneLine = "Warning only one line read from file ";
        public const string logMessageUnableToParseLine = "Unable to parse line - ";
        public const string logMessageLength = "length < 3 Line=";
        public const char splitChar = ',';
        public const string argumentExceptionLongitude = "Invalid Value for longitude greater than 180.00 or less than -180.00";
        public const string argumentExceptionLatitude = "Invalid Value for latitude greater than 90.00 or less than -90.00";
        public const double milesPerMeter = 0.00062137;
        public const byte minCells = 2;
    }
}