using System;

public class Forecast
{
    private Place _place;
    private Weather _weather;

    public Forecast(Place place)
    {
        _place = place;
    }

    public void DisplayCurrent()
    {
        string title = $"CURRENT WEATHER FOR {_place.GetShortName()} AS OF "
                + _weather.GetForecastTime().ToString("dddd, h:mm tt");
        Menu currentForecast = new(title);
        currentForecast.Display();
        string sunrise = _weather.UtcUnixToLocalDateTime(_weather.GetCurrent(
                ).sunrise).ToString("HH:mm");
        string sunset = _weather.UtcUnixToLocalDateTime(_weather.GetCurrent(
                ).sunset).ToString("HH:mm");
        string temp = $"{_weather.GetCurrent().temp}{'\u2109'}";
        string feel = $"{_weather.GetCurrent().feels_like}{'\u2109'}";
        string speed = $"{_weather.GetCurrent().wind_speed}mph";
        string direction = $"{_weather.GetCurrent().wind_deg}{'\u00B0'}";
        Console.WriteLine($"Sunrise: {sunrise} Temperature: {temp}     Wind Speed: {speed}");
        Console.WriteLine($" Sunset: {sunset}  Feels like: {feel} Wind Direction: {direction}");
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayDaily()
    {
        if (DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset())
                < _weather.GetLastDay())
        {
            string title = $"DAILY FORECAST FOR {_place.GetShortName()} UNTIL "
                + _weather.GetLastDay().ToString("dddd");
            Menu dailyForecast = new(title);
            dailyForecast.Display();
            foreach (Daily day in _weather.GetDailies())
            {
                string time = _weather.UtcUnixToLocalDateTime(day.dt).ToString("dddd");
                string sunrise = _weather.UtcUnixToLocalDateTime(day.sunrise)
                        .ToString("HH:mm");
                string sunset = _weather.UtcUnixToLocalDateTime(day.sunset)
                        .ToString("HH:mm");
                string moonrise = _weather.UtcUnixToLocalDateTime(day.moonrise)
                        .ToString("HH:mm");
                string moonset = _weather.UtcUnixToLocalDateTime(day.moonset)
                        .ToString("HH:mm");
                
                string temp = $"{day.temp}{'\u2109'}";
                string feel = $"{day.feels_like}{'\u2109'}";
                string speed = $"{day.wind_speed}mph";
                string direction = $"{day.wind_deg}{'\u00B0'}";
                Console.WriteLine(time);
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 72)));
                Console.WriteLine($"Sunrise: {sunrise} Temperature: {temp}     Wind Speed: {speed}");
                Console.WriteLine($" Sunset: {sunset}  Feels like: {feel} Wind Direction: {direction}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Daily forecasts expired. Please update forecast.");
        }
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayHourly()
    {
        if (DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset())
                < _weather.GetLastHour())
        {
            string title = $"HOURLY FORECAST FOR {_place.GetShortName()} UNTIL "
                + _weather.GetLastHour().ToString("h tt");
            Menu hourlyForecast = new(title);
            hourlyForecast.Display();
            foreach (Hourly hour in _weather.GetHourlies())
            {
                string time = _weather.UtcUnixToLocalDateTime(hour.dt).ToString("hh tt");
                string temp = $"{hour.temp}{'\u2109'}";
                string feel = $"{hour.feels_like}{'\u2109'}";
                string speed = $"{hour.wind_speed}mph";
                string direction = $"{hour.wind_deg}{'\u00B0'}";
                Console.WriteLine($"{time} - Temperature: {temp}     Wind Speed: {speed}");
                Console.WriteLine($"         Feels like: {feel} Wind Direction: {direction}");
            }
        }
        else
        {
            Console.WriteLine("Hourly forecasts expired. Please update forecast.");
        }
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayMinutely()
    {
        if (DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset())
                < _weather.GetLastMinute())
        {
            string title = $"MINUTELY FORECAST FOR {_place.GetShortName()} UNTIL "
                + _weather.GetLastMinute().ToString("h:mm tt");
            Menu minutelyForecast = new(title);
            minutelyForecast.Display();
            foreach (Minutely minute in _weather.GetMinutelies())
            {
                string time = _weather.UtcUnixToLocalDateTime(minute.dt).ToString("HH:mm");
                Console.WriteLine($"{minute.precipitation} mm/h of precipitation forecast for {time}");
            }
        }
        else
        {
            Console.WriteLine("Minutely forecasts expired. Please update forecast.");
        }
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public (string, string) GetCoordinates()
    {
        return (_place.GetLatitude(), _place.GetLongitude());
    }

    public string PutCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        currentTime = currentTime.AddSeconds(_weather.GetTimeZoneOffset());
        return currentTime.ToString("dddd, h:mm tt");
    }

    public string PutDailyOption()
    {
        string dateTime = _weather.GetLastDay().ToString("dddd");
        if (DateTime.Now > _weather.GetLastDay())
        {            
            return $"Daily forecasts until {dateTime}";
        }
        return $"Daily forecasts expired {dateTime}";        
    }

    public string PutElapsedTime()
    {
        TimeSpan interval = DateTime.Now - _weather.GetForecastTime();
        if (interval.TotalSeconds < 120)
        {
            return $"{(int) interval.TotalSeconds:D} seconds";
        }
        else if (interval.TotalMinutes < 120)
        {
            return $"{(int) interval.TotalMinutes:D} minutes";
        }
        else if (interval.TotalHours < 48)
        {
            return $"{(int) interval.TotalHours:D} hours";
        }
        return $"{(int) interval.TotalDays:D} days";
    }

    public string PutForecastTime()
    {
        return _weather.GetForecastTime().ToString("dddd, h:mm tt");
    }

    public string PutHourlyOption()
    {
        string dateTime = _weather.GetLastHour().ToString("dddd, h tt");
        if (DateTime.Now > _weather.GetLastHour())
        {            
            return $"Hourly forecast until {dateTime}";
        }
        return $"Hourly forecasts expired {dateTime}";        
    }

    public string PutLongPlaceName()
    {
        return _place.GetLongName();
    }

    public string PutMinutelyOption()
    {
        string dateTime = _weather.GetLastMinute().ToString("dddd, h:mm tt");
        if (DateTime.Now > _weather.GetLastMinute())
        {            
            return $"Minutely forecast until {dateTime}";
        }
        return $"Minutely forecasts expired {dateTime}";        
    }

    public string PutShortPlaceName()
    {
        return _place.GetShortName();
    }

    public void UpdateWeather(Weather weather)
    {
        _weather = weather;
    }


    public DateTime UtcUnixToLocalDateTime(int unixUtc)
    {
        DateTime dateTime = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(unixUtc + _weather.GetTimeZoneOffset());
    }
}