using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // API URL for Open Meteo
        private string APIURL = "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";

        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void getWeather()
        {
            // Example coordinates for Berlin, Germany
            double latitude = 52.52;
            double longitude = 13.41;

            using (WebClient web = new WebClient())
            {
                try
                {
                    string url = string.Format(APIURL, latitude, longitude);
                    string json = web.DownloadString(url);

                    // Deserialize the JSON response into the WeatherInfo class
                    WeatherInfo.Root info = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                    // Display the current temperature and wind speed
                    lblTemperature.Text = $"Temperature: {info.current.temperature_2m} °C";
                    lblWindSpeed.Text = $"Wind Speed: {info.current.wind_speed_10m} m/s";

                    // Display hourly data (for example, the first hour)
                    if (info.hourly.time.Count > 0)
                    {
                        lblHourlyTemperature.Text = $"Next Hour Temp: {info.hourly.temperature_2m[0]} °C";
                        lblHourlyWindSpeed.Text = $"Next Hour Wind Speed: {info.hourly.wind_speed_10m[0]} m/s";
                        lblHourlyHumidity.Text = $"Next Hour Humidity: {info.hourly.relative_humidity_2m[0]} %";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching weather data: " + ex.Message);
                }
            }
        }
    }
}