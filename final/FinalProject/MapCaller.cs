using System;

public class MapCaller : ApiCaller
{
    private string _baseUrl 
            = "https://maps.googleapis.com/maps/api/geocode/";
    private string _key = "AIzaSyBbSy-ZSL9fw-ukvAUxrxXUDgaek_P25EQ";
    private string _relativeUrl;

    public MapCaller(string search)
    {
        SetBaseUrl(_baseUrl);
        _relativeUrl = $"json?address={search.Replace(' ', '+')}&key={_key}";
    }

    public override async Task<Forecast> Call()
    {
        MapResponse response = await GetReponse<MapResponse>(_relativeUrl);

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