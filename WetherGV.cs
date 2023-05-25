/* Basic Maui App requesting the Open Weather API
 * And displaying the curent temp to screen
 * 
 * By Benjamin Boden
 * UVU ID: 10760739
 * INFO 2200
 * Prof. Kodey Crandle
 * 
 * wether class for Global variables
 */

// using this namespace
namespace FinalProject_5
{
    /// <summary>
    /// Global variables class for the app
    /// </summary>
    public static class WetherGV
    {
        public static string CityName { get; set; } // string with the City Name
        public static double CurentTemp { get; set; }  // curent temp as duble
        public static double MaxTemp { get; set; }  // max temp as double
        public static double MinTemp { get; set; } // min temp as double
        public static double Humidity { get; set; } // gets the % Humidity
        public static double pressure { get; set; } // gets the pressuer at sea leval
        public static double WindSpeed {get; set; } // gets wind speed in Miles/Hour

        private static double WindDeg; // gets the direction of wind as North, South, East, West
        
        private static double SunRise; // privat var sunrise

        private static double SunSet; // privat var sunset

        /// <summary>
        /// Set() function for sunrise
        /// </summary>
        /// <param name="sunRise"></param>
        public static void SetSunRise(double sunRise) { SunRise = sunRise; }      


        /// <summary>
        /// Get() function for sunrise
        /// </summary>
        /// <returns> string of date/time</returns>
        public static string GetSunRise()
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(SunRise).ToLocalTime();

            // Return the date & time as string
            return dateTime.ToString();
        }


        /// <summary>
        /// Set() function for var sunset
        /// </summary>
        /// <param name="sunSet"></param>
        public static void SetSunset(double sunSet) { SunSet = sunSet; }

        /// <summary>
        /// Get() function for var Sunset
        /// </summary>
        /// <returns>string: date/time</returns>
        public static string GetSunSet()
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(SunSet).ToLocalTime();

            // Return the date & time as string
            return dateTime.ToString();
        }


        /// <summary>
        /// Set() function for WindDeg
        /// </summary>
        /// <param name="windAngle"></param>
        public static void SetWindDeg(double windAngle) { WindDeg = windAngle; }

        /// <summary>
        /// Get() function for WindDeg
        /// </summary>
        /// <returns>String: windDirection</returns>
        public static string GetWindDeg()
        {
            string windDirection = "";// set local variable

            // Note: should be moved to switch case for wind angle
            if (WindDeg == 0)  windDirection = "Winds from: N"; // set to this
            if (WindDeg <= 90 && WindDeg >= 0) windDirection = "Winds from: NE"; // set to this
            if (WindDeg == 90) windDirection = "Winds from: E"; // set to this
            if (WindDeg <= 180 && WindDeg >= 90) windDirection = "Winds from: SE"; // set to this
            if (WindDeg == 180) windDirection = "Winds from: S"; // set to this
            if (WindDeg <= 270 && WindDeg >= 180) windDirection = "Winds from: SW"; // set to this
            if (WindDeg == 0) windDirection = "Winds from: W"; // set to this
            if (WindDeg <= 360 && WindDeg >= 270) windDirection = "Winds from: NW"; // set to this

            return windDirection; // returned what was set
        }
    }

}
