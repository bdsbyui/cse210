using System;

public class Forecasts
{
    private List<Forecast> _forecasts;
    
    public Forecasts()
    {
        _forecasts = new List<Forecast>();
    }

    public void Add(Forecast forecast)
    {
        _forecasts.Add(forecast);
    }
    
    public Forecast AccessForecast(int index)
    {
        return _forecasts[index];
    }

    public int Count()
    {
        int count;
        try
        {
            count = _forecasts.Count();
        }
        catch (ArgumentNullException)
        {
            count = 0;
        }
        return count;
    }

    public List<string> PutOptions()
    {
        List<string> options = new();
        foreach (Forecast forecast in _forecasts)
        {
            options.Add(forecast.PutLongPlaceName());
        }
        return options;
    }
}