using System;
using Newtonsoft.Json;

public class MapCaller : ApiCaller
{
    // pending parsing
    private string url = "https://maps.googleapis.com/maps/api/geocode/json?address=11762+Gascony+Place,+Woodbridge,+VA&key=AIzaSyBbSy-ZSL9fw-ukvAUxrxXUDgaek_P25EQ";
    private string _search;

    public MapCaller(string search)
    {
        _search = search;
    }

    public override async Task<Forecast> Lookup()
    {
        string json = await base._client.GetStringAsync(url); // pending parsing
        MapResponse response = JsonConvert.DeserializeObject<MapResponse>(json);
        string locality = GetAddressComponent
        (
            response.results[0].address_components, "locality"
        );
        string address = response.results[0].formatted_address;
        double latitude = response.results[0].geometry.location.lat;
        double longitude = response.results[0].geometry.location.lng;
        Place place = new(locality, address, latitude, longitude);
        Forecast forecast = new(place);
        return forecast;
    }

    private string GetAddressComponent
    (
        List<AddressComponent> components,
        string typeLabel
    )
    {
        string componentName = default;
        foreach (AddressComponent component in components)
        {
            foreach (string type in component.types)
            {
                if (type == typeLabel)
                {
                    componentName = component.short_name;
                }
            }
        }
        return componentName;
    }
}