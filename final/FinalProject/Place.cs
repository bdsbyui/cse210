using System;

public class Place
{
    private string _shortName;
    private string _longName;
    private string _latitude;
    private string _longitude;

    public Place
    (
        string locality,
        string address,
        double latitude,
        double longitude
    )
    {
        _shortName = locality;
        _longName = address;
        _latitude = latitude.ToString();
        _longitude = longitude.ToString();
    }

    public string GetLongName()
    {
        return _longName;
    }

    public string GetShortName()
    {
        return _shortName;
    }
}