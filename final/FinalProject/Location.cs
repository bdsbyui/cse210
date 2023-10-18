using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Location
{
    public string timezone { get; set; }
    public int timezone_offset { get; set; }


}
// public record class Location(string formatted_address);