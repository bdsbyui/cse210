using System;

public class WeatherCaller : ApiCaller
{
    private string _baseUrl = "https://api.openweathermap.org/data/3.0/";
    private string _key = "040c9732ca7f6f93a9be29e9c6078796";
    private string _relativeUrl;
    private string _units = "imperial";
    private Forecast _forecast;

    public WeatherCaller(Forecast forecast)
    {
        _forecast = forecast;
        SetBaseUrl(_baseUrl);
        (string latitude, string longitude) = forecast.GetCoordinates();
        _relativeUrl = $"onecall?lat={latitude}&lon={longitude}&units={_units}&appid={_key}";
    }

    public override async Task Call()
    {
        WeatherResponse response = await GetReponse<WeatherResponse>(_relativeUrl);
        Weather weather = new(response);
        _forecast.UpdateWeather(weather);
    }
}




