using System;
using System.Net.Http.Headers;

using System.Text.Json;
// using System.Text.Json.Serializer;

public class ApiCaller
{
    HttpClient _client;

    public ApiCaller()
    {
        _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task Lookup()
    {
        var json = await _client.GetStringAsync(
            "https://api.openweathermap.org/data/3.0/onecall?lat=38.6977604&lon=-77.32165239999999&appid=040c9732ca7f6f93a9be29e9c6078796");
        // Console.Write(json);

        Location location = new();
        location = JsonSerializer.Deserialize<Location>(json);
        Console.WriteLine($"{location.timezone}");
    }
}

// using HttpClient client = new();
// client.DefaultRequestHeaders.Accept.Clear();
// client.DefaultRequestHeaders.Accept.Add(
//     new MediaTypeWithQualityHeaderValue("application/json"));

// await GetWeatherAsync(client);

// static async Task GetWeatherAsync(HttpClient client)
//  {
//      var json = await client.GetStringAsync(
//          "https://maps.googleapis.com/maps/api/geocode/json?address=11762+Gascony+Place,+Woodbridge,+VA&key=AIzaSyBbSy-ZSL9fw-ukvAUxrxXUDgaek_P25EQ");

//      Console.Write(json);
//  }


// using System.Net.Http.Headers;




// using System;
// using System.Net;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using System.Text.Json;

// public class ApiCall
// {
//     private string _url
//         = "https://maps.googleapis.com/maps/api/geocode/json?address=";
//     private string _path
//         = "11762+Gascony+Place,+Woodbridge,+VA&key=AIzaSyBbSy-ZSL9fw-ukvAUxrxXUDgaek_P25EQ";
//     private HttpClient _client;
//     private Location _location;

//     public ApiCall()
//     {
//         _client = new HttpClient();
//         _client.BaseAddress = new Uri(_url);
//         _client.DefaultRequestHeaders.Accept.Clear();
//         _client.DefaultRequestHeaders.Accept.Add(
//                 new MediaTypeWithQualityHeaderValue("application/json"));

//     }

//     private void ShowLocation(Location location)
//     {
//         Console.WriteLine($"Showing: {location.Address}");
//     }
    
//     private async void GetLocation(string path)
//     {
//         _location = new();
//         HttpResponseMessage response = await _client.GetAsync(path);
//         if (response.IsSuccessStatusCode)
//         {
//             string jsonString = await response.Content.ReadAsStringAsync();
//             _location = JsonSerializer.Deserialize<Location>(jsonString);
//         }
//     }

//     public async void Test()
//     {
//         return await RunAsync().GetAwaiter().GetResult();
//     }

//     private async void RunAsync()
//     {
//     //     _client.BaseAddress = new Uri(_url);
//     //     _client.DefaultRequestHeaders.Accept.Clear();
//     //     _client.DefaultRequestHeaders.Accept.Add(
//     //         new MediaTypeWithQualityHeaderValue("application/json"));

//         try
//         {
//             await GetLocation(_path);
//             ShowLocation(_location);
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//         }
//     }
// }