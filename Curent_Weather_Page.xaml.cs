/* Basic Maui App requesting the Open Weather API
 * And displaying the curent temp to screen
 * 
 * By Benjamin Boden
 * UVU ID: 10760739
 * INFO 2200
 * Prof. Kodey Crandle
 * 
 * This is the display screen
 */

// our namespace
namespace FinalProject_5;

/// <summary>
/// The Class defining our curent weather page
/// </summary>
public partial class Curent_Weather_Page : ContentPage
{
    /// <summary>
    /// __init__ statment for the class
    /// </summary>
	public Curent_Weather_Page()
	{
		InitializeComponent();

        LblCity.Text = WetherGV.CityName; // set the name
        LblCurTem.Text = $"curent temp: {WetherGV.CurentTemp}"; // set the curent temp
        LblHighTemp.Text = $"High: {WetherGV.MaxTemp}"; // get the max temp
        LblLowTemp.Text = $"Low: {WetherGV.MinTemp}"; // get the low temp
        Lblhumidity.Text = $"Humidity: %{WetherGV.Humidity}"; // get the humidity
        Lblpressuer.Text = $"Pressuer: {WetherGV.pressure}"; // get the atmospheric presser
        LblWindDeg.Text = WetherGV.GetWindDeg(); // get the wind direcion as string 
        LblWindSpeed.Text = $"Wind Speed: {WetherGV.WindSpeed}mph"; // get wind speed in MPH
        LblSunRise.Text = $"Sun Rise: {WetherGV.GetSunRise()}"; // get the sun rise as string of time
        LblSunSet.Text = $"Sun Set: {WetherGV.GetSunSet()}"; // get the sunset as string of time
        backgroundSet(); // change the background color depending on curent temp
    }

    /// <summary>
    /// Depending on the temprituer, change the screen background color
    /// </summary>
    public void backgroundSet()
    {
        string colorHex; // init local variable
        
        switch (WetherGV.CurentTemp) // depenining on the curent temp
        {
            case double i when i <= 32: // if below frezzing
                colorHex = "#C8E9E9"; // ice blue
                break;// exit switch
            case double i when i > 32 && i <= 72: // if below room temp
                colorHex = "#A1D269"; // easter green
                break; // exit switch
            case double i when i > 72 && i <= 100: // if above room temp
                colorHex = "#D76B00"; //pumpkin orange
                break; // exit switch
            case double i when i > 100: // if hot as heck
                colorHex = "#D15162"; // summer red
                break; // exit switch
            default: // defalt seting
                colorHex = "#01821F"; // set to Kelly Green
                break; // exit switch
        }

        StackLayout.BackgroundColor = Color.FromArgb(colorHex); // set background color
    }
}