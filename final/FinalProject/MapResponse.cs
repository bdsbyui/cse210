using System;

public class MapResponse
{
    public List<Result> results { get; set; }
    public string status { get; set; }
}

public class Result
{
    public List<AddressComponent> address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
}

public class AddressComponent
{
    public string short_name { get; set; }
    public List<string> types { get; set; }
}

public class Geometry
{
    public Location location { get; set; }
}

public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}
