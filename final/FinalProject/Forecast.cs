using System;

public class Forecast
{
    private Place _place;
    private Weather _weather;

    public Forecast(Place place)
    {
        _place = place;
    }

    public void DisplayAlerts()
    {
        Console.WriteLine("alerts-placeholder");
        Console.Write("Continue?");
        Console.ReadLine();
    }

    public void DisplayCurrent()
    {
        Console.WriteLine("current-placeholder");
        Console.Write("Continue?");
        Console.ReadLine();
    }

    public void DisplayDaily()
    {
        Console.WriteLine("daily-placeholder");
        Console.Write("Continue?");
        Console.ReadLine();
    }

    public void DisplayHourly()
    {
        Console.WriteLine("hourly-placeholder");
        Console.Write("Continue?");
        Console.ReadLine();
    }

    public void DisplayMinutely()
    {
        Console.WriteLine("minutely-placeholder");
        Console.Write("Continue?");
        Console.ReadLine();
    }

    public string PutCurrentTime()
    {
        return "current-time-placeholder";
    }

    public string PutElapsedTime()
    {
        return "elapsed-time-placeholder";
    }

    public string PutForecastTime()
    {
        return "forecast-time-placeholder";
    }

    public string PutLatestDay()
    {
        return "latest-day-placeholder";
    }

    public string PutLatestHour()
    {
        return "latest-hour-placeholder";
    }

    public string PutLatestMinute()
    {
        return "latest-minute-placeholder";
    }

    public string PutLongPlaceName()
    {
        return _place.GetLongName();
    }

    public string PutShortPlaceName()
    {
        return _place.GetShortName();
    }

    public void UpdateWeather(Weather weather)
    {
        _weather = weather;
    }
}