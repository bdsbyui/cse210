using System;

public class Weather
{
    private int _localOffset;
    private DateTime _forecastTime;
    private DateTime _lastDay;
    private DateTime _lastHour;
    private DateTime _lastMinute;
    private Current _currentForecast;
    private List<Minutely> _minutelies;
    private List<Hourly> _hourlies;
    private List<Daily> _dailies;

    public Weather(WeatherResponse response)
    {
        _localOffset = response.timezone_offset;
        _forecastTime = UtcUnixToLocalDateTime(response.current.dt);
        _currentForecast = response.current;
        _minutelies = response.minutely;
        _lastMinute = UtcUnixToLocalDateTime(_minutelies.Last().dt);
        _hourlies = response.hourly;
        _lastHour = UtcUnixToLocalDateTime(_hourlies.Last().dt);
        _dailies = response.daily;
        _lastDay = UtcUnixToLocalDateTime(_dailies.Last().dt);
    }

    public Current GetCurrent()
    {
        return _currentForecast;
    }

    public List<Daily> GetDailies()
    {
        return _dailies;
    }

    public DateTime GetForecastTime()
    {
        return _forecastTime;
    }

    public List<Hourly> GetHourlies()
    {
        return _hourlies;
    }

    public DateTime GetLastDay()
    {
        return _lastDay;
    }

    public DateTime GetLastHour()
    {
        return _lastHour;
    }

    public DateTime GetLastMinute()
    {
        return _lastMinute;
    }

    public List<Minutely> GetMinutelies()
    {
        return _minutelies;
    }

    public int GetTimeZoneOffset()
    {
        return _localOffset;
    }

    public DateTime UtcUnixToLocalDateTime(int unixUtc)
    {
        DateTime dateTime = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(unixUtc + _localOffset);
    }
}