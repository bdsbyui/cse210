using System;
using Newtonsoft.Json;

public class WeatherCaller : ApiCaller
{
    // pending parsing
    private string url = "https://api.openweathermap.org/data/3.0/onecall?lat=38.6977604&lon=-77.32165239999999&appid=040c9732ca7f6f93a9be29e9c6078796";
    private Forecast _forecast;

    public WeatherCaller(Forecast forecast)
    {
        _forecast = forecast;
    }

    public override async Task Lookup()
    {
        string json = await base._client.GetStringAsync(url); // pending parsing
        Weather response = JsonConvert.DeserializeObject<Weather>(json);
        _forecast.UpdateWeather(response);
    }

}




