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
        DateTime forecastTime = UtcUnixToLocalDateTime(_weather.GetCurrent().dt);
        string title = $"CURRENT WEATHER FOR {_place.GetShortName()} AS OF "
                + forecastTime.ToString("dddd, h:mm tt");

        Menu currentForecast = new(title);
        currentForecast.Display();

        string temp = $"{(int) _weather.GetCurrent().temp:D}{'\u2109'}";
        string feel = $"{(int) _weather.GetCurrent().feels_like:D}{'\u2109'}";
        string wspd = $"{(int) _weather.GetCurrent().wind_speed:D} mph";
        string wdir = $"{_weather.GetCurrent().wind_deg}{'\u00B0'}";
        string sris = UtcUnixToLocalDateTime(_weather.GetCurrent().sunrise).ToString("HH:mm");
        string sset = UtcUnixToLocalDateTime(_weather.GetCurrent().sunset).ToString("HH:mm");

        Console.WriteLine
        (
            $"\t{"Temperature:",12} {temp,5}  {"Wind speed:",15} {wspd,-7}  {"Sunrise:",8} {sris} hrs"
        );
        Console.WriteLine
        (
            $"\t{"Feels like:",12} {feel,5}  {"Wind direction:",15} {wdir,-7}  {"Sunset:",8} {sset} hrs"
        );
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayDaily()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expiration = UtcUnixToLocalDateTime(_weather.GetDailies().Last().dt);
        if (now < expiration)
        {
            string title = $"DAILY FORECAST FOR {_place.GetShortName()} UNTIL "
                    + expiration.ToString("dddd");
            
            Menu dailyForecast = new(title);
            dailyForecast.Display();
            
            foreach (Daily day in _weather.GetDailies())
            {
                DateTime dt = UtcUnixToLocalDateTime(day.dt);
                if (now < dt)
                {
                    string time = dt.ToString("dddd, MMM d");
                    string smry = day.summary;
                    string tmax = $"{(int) day.temp.max:D}{'\u2109'}";
                    string tmin = $"{(int) day.temp.min:D}{'\u2109'}";
                    string tmrn = $"{(int) day.temp.morn:D}{'\u2109'}";
                    string tday = $"{(int) day.temp.day:D}{'\u2109'}";
                    string teve = $"{(int) day.temp.eve:D}{'\u2109'}";
                    string tngt = $"{(int) day.temp.night:D}{'\u2109'}";
                    string fmrn = $"{(int) day.feels_like.morn:D}{'\u2109'}";
                    string fday = $"{(int) day.feels_like.day:D}{'\u2109'}";
                    string feve = $"{(int) day.feels_like.eve:D}{'\u2109'}";
                    string fngt = $"{(int) day.feels_like.night:D}{'\u2109'}";
                    string wspd = $"{(int) day.wind_speed:D} mph";
                    string wdir = $"{day.wind_deg}{'\u00B0'}";
                    string sris = UtcUnixToLocalDateTime(day.sunrise).ToString("HH:mm");
                    string sset = UtcUnixToLocalDateTime(day.sunset).ToString("HH:mm");
                    string mris = UtcUnixToLocalDateTime(day.moonrise).ToString("HH:mm");
                    string mset = UtcUnixToLocalDateTime(day.moonset).ToString("HH:mm");

                    Console.WriteLine(time);
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 27)));
                    Console.WriteLine(smry);
                    Console.WriteLine
                    (
                        $"\t{"High:",-5}   {tmrn,5} morning {fmrn,-5}   {"Speed:",-10}   {"Sunrise:",9} {sris} hrs"
                    );
                    Console.WriteLine
                    (
                        $"\t{tmax,5}   {tday,5}   day   {fday,-5}   {wspd,10}   {"Sunset:",9} {sset} hrs"
                    );
                    Console.WriteLine
                    (
                        $"\t{"Low:",-5}   {teve,5} evening {feve,-5}   {"Direction:",-10}   {"Moonrise:",9} {mris} hrs"
                    );
                    Console.WriteLine
                    (
                        $"\t{tmin,5}   {tngt,5}  night  {fngt,-5}   {wdir,10}   {"Moonset:",9} {mset} hrs"
                    );
                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Daily forecasts have expired. Please update the forecast.");
        }
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayHourly()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expiration = UtcUnixToLocalDateTime(_weather.GetHourlies().Last().dt);
        if (now < expiration)
        {
            string title = $"HOURLY FORECAST FOR {_place.GetShortName()} UNTIL "
                    + expiration.ToString("dddd h tt");
            
            Menu hourlyForecast = new(title);
            hourlyForecast.Display();
            
            foreach (Hourly hour in _weather.GetHourlies())
            {
                DateTime dt = UtcUnixToLocalDateTime(hour.dt);
                if (now < dt)
                {
                    string time = dt.ToString("h tt");
                    string temp = $"{(int) hour.temp:D}{'\u2109'}";
                    string feel = $"{(int) hour.feels_like:D}{'\u2109'}";
                    string wspd = $"{(int) hour.wind_speed:D} mph";
                    string wdir = $"{hour.wind_deg}{'\u00B0'}";

                    Console.WriteLine
                    (
                        $"\t{time,5} --     {"Temperature:",12} {temp,5}     {"Wind speed:",15} {wspd,-10}"
                    );
                    Console.WriteLine
                    (
                        $"\t{"",5}        {"Feels like:",12} {feel,5}     {"Wind direction:",15} {wdir,-10}"
                    );
                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Hourly forecasts have expired. Please update the forecast.");
        }
        Console.WriteLine();
        Console.Write("Press <Enter> to continue.");
        Console.ReadLine();
    }

    public void DisplayMinutely()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expiration = UtcUnixToLocalDateTime(_weather.GetMinutelies().Last().dt);
        if (now < expiration)
        {
            string title = $"MINUTELY FORECAST FOR {_place.GetShortName()} UNTIL "
                    + expiration.ToString("h:mm tt");
            
            Menu minutelyForecast = new(title);
            minutelyForecast.Display();
            
            foreach (Minutely minute in _weather.GetMinutelies())
            {
                DateTime dt = UtcUnixToLocalDateTime(minute.dt);
                if (now < dt)
                {
                    string time = dt.ToString("h:mm tt");
                    string prcp = minute.precipitation.ToString();

                    Console.WriteLine
                    (
                        $"The forecast is for {prcp} mm/hr of precipitation at {time}."
                    );
                }
            }
        }
        else
        {
            Console.WriteLine("Minutely forecasts have expired. Please update the forecast.");
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
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        return now.ToString("dddd, h:mm tt");
    }

    public string PutForecastTime()
    {
        DateTime forecastTime = UtcUnixToLocalDateTime(_weather.GetCurrent().dt);
        return forecastTime.ToString("dddd, h:mm tt");
    }

    public string PutElapsedTime()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime forecastTime = UtcUnixToLocalDateTime(_weather.GetCurrent().dt);
        TimeSpan interval = now - forecastTime;
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

    public string PutMinutelyOption()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expirationDt = UtcUnixToLocalDateTime(_weather.GetMinutelies().Last().dt);
        string expirationStr = expirationDt.ToString("h:mm tt");
        if (now < expirationDt)
        {            
            return $"Minutely forecast until {expirationStr}";
        }
        return $"Minutely forecasts expired {expirationStr}";        
    }

    public string PutHourlyOption()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expirationDt = UtcUnixToLocalDateTime(_weather.GetHourlies().Last().dt);
        string expirationStr = expirationDt.ToString("h tt");
        if (now < expirationDt)
        {            
            return $"Hourly forecast until {expirationStr}";
        }
        return $"Hourly forecasts expired {expirationStr}";        
    }

    public string PutDailyOption()
    {
        DateTime now = DateTime.UtcNow.AddSeconds(_weather.GetTimeZoneOffset());
        DateTime expirationDt = UtcUnixToLocalDateTime(_weather.GetDailies().Last().dt);
        string expirationStr = expirationDt.ToString("dddd");
        if (now < expirationDt)
        {            
            return $"Daily forecasts until {expirationStr}";
        }
        return $"Daily forecasts expired {expirationStr}";
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

    public DateTime UtcUnixToLocalDateTime(int unixUtc)
    {
        DateTime dateTime = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(unixUtc + _weather.GetTimeZoneOffset());
    }
}