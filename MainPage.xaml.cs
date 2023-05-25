/* Basic Maui App requesting the Open Weather API
 * And displaying the curent temp to screen
 * 
 * By Benjamin Boden
 * UVU ID: 10760739
 * INFO 2200
 * Prof. Kodey Crandle
 * 
 * This is the mane program page when the app lonches
 */

// import some stuff
using Newtonsoft.Json.Linq;
using System.Net;

namespace FinalProject_5;

public partial class MainPage : ContentPage
{
    const string API_KEY = "2df5c2c86c6894540efe9a299d91f107"; // our api key


    /// <summary>
    /// init main page
    /// </summary>
    public MainPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// When the buttton is clicked
    /// acess the api and save serten elements
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnSearch_Clicked(object sender, EventArgs e)
	{
        if (EntryZip.Text != null) // if they tiped something
        {
            try
            {
                using (WebClient wc = new WebClient()) // start this class
                {
                    // request the json text as string
                    string jsonResponce = wc.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={EntryZip.Text}&appid={API_KEY}&units=imperial");

                    JObject jo = JObject.Parse(jsonResponce); // parse to json object
                    JObject joMain = JObject.Parse(jo["main"].ToString()); // parse part to new objcet
                    JObject joWind = JObject.Parse(jo["wind"].ToString());
                    JObject joSys = JObject.Parse(jo["sys"].ToString());

                    WetherGV.CityName = jo["name"].ToString(); // access this elemte

                    WetherGV.CurentTemp = double.Parse(joMain["temp"].ToString()); // save this element
                    WetherGV.MaxTemp = double.Parse(joMain["temp_max"].ToString()); // save this element
                    WetherGV.MinTemp = double.Parse(joMain["temp_min"].ToString()); // save this element
                    WetherGV.pressure = double.Parse(joMain["pressure"].ToString()); // save this element
                    WetherGV.Humidity = double.Parse(joMain["humidity"].ToString()); // save this element
                    WetherGV.WindSpeed = double.Parse(joWind["speed"].ToString()); // save this element

                    WetherGV.SetWindDeg(double.Parse(joWind["deg"].ToString()));  // save this element
                    WetherGV.SetSunRise(double.Parse(joSys["sunrise"].ToString()));  // save this element
                    WetherGV.SetSunset(double.Parse(joSys["sunset"].ToString()));  // save this element

                    //WetherGV.SunRise = double.Parse(joSys["sunrise"].ToString());
                    //WetherGV.SunSet = double.Parse(joSys["sunset"].ToString());
                }
            }
            catch
            {
                DisplayAlert("This is an error", "Try/Catch broke", "Close"); // display a problem

            }


            Navigation.PushAsync(new Curent_Weather_Page());  // shows a new window. equivelent of showDiolog() in WPF

        }
        else // if nothing is typed
        {
            DisplayAlert("This is an error", "Please enter a zip Code", "Close"); // display a problem
        }

    }
}


