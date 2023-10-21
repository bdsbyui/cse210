using System;
using Newtonsoft.Json;

public class MapResponse
{
    public List<Result> results { get; set; }
    public string status { get; set; }
}

public class AddressComponent
{
    public string long_name { get; set; }
    public string short_name { get; set; }
    public List<string> types { get; set; }
}

public class Bounds
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}

public class Geometry
{
    public Bounds bounds { get; set; }
    public Location location { get; set; }
    public string location_type { get; set; }
    public Viewport viewport { get; set; }
}

public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Northeast
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Result
{
    public List<AddressComponent> address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
    public string place_id { get; set; }
    public List<string> types { get; set; }
}

public class Southwest
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Viewport
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}




















// public class MapResponse
// {
//     public results[] results { get; set; }
//     public string status { get; set; }
// }
 
// public class results
// {
//     public address_component[] address_components { get; set; }
//     public string formatted_address { get; set; }
//     public geometry geometry { get; set; }
//     public string partial_match { get; set; }
//     public string[] types { get; set; }
// }
 
// public class geometry
// {
//     public bounds bounds { get; set; }
//     public location location { get; set; }
//     public string location_type { get; set; }
//     public viewport viewport { get; set; }
// }
 
// public class bounds
// {
//     public northeast northeast { get; set; }
//     public southwest southwest { get; set; }
// }
 
// public class viewport
// {
//     public northeast northeast { get; set; }
//     public southwest southwest { get; set; }
// }
 
// public class northeast : location
// {
// }
 
// public class southwest : location
// {
// }
 
// public class location
// {
//     public decimal lat { get; set; }
//     public decimal lng { get; set; }
// }
 
// public class address_component
// {
//     public string long_name { get; set; }
//     public string short_name { get; set; }
//     public string[] types { get; set; }
// }







// {
//     public ResponseResults[] results { get; set; }
//     public string status { get; set; }

//     // [JsonPropertyName("results")]
//     // [JsonConverter(typeof(InfotoStringConverter))]
//     // public IEnumerable<string> Results { get; set; }
// }
// public class ResponseResults
// {
//     public AddressComponents[] address_components { get; set; }
//     public string fomatted_address { get; set; }

// }
// public class AddressComponents
// {
//     public string long_name { get; set; }
//     public string short_name { get; set; }
//     public string[] types { get; set; }
// }
// public class Geometry
// {
//     public Location location { get; set; }
// }
// public class Location
// {
//     public string lat { get; set; }
//     public string lng { get; set; }
// }