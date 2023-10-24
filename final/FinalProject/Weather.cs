using System;

public class Weather
{
    private int _localOffset;
    private Current _currentForecast;
    private List<Minutely> _minutelies;
    private List<Hourly> _hourlies;
    private List<Daily> _dailies;

    public Weather(WeatherResponse response)
    {
        _localOffset = response.timezone_offset;
        _currentForecast = response.current;
        _minutelies = response.minutely;
        _hourlies = response.hourly;
        _dailies = response.daily;
    }

    public Current GetCurrent()
    {
        return _currentForecast;
    }

    public List<Daily> GetDailies()
    {
        return _dailies;
    }

    public List<Hourly> GetHourlies()
    {
        return _hourlies;
    }

    public List<Minutely> GetMinutelies()
    {
        return _minutelies;
    }

    public int GetTimeZoneOffset()
    {
        return _localOffset;
    }
}