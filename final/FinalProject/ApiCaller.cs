using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;

public abstract class ApiCaller
{
    protected HttpClient _client;

    public ApiCaller()
    {
        _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add
        (
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }

    public abstract Task Call();

    public async Task<T> GetReponse<T>(string uri)
    {
        string json = await _client.GetStringAsync(uri);
        return JsonConvert.DeserializeObject<T>(json);
    }

    public void SetBaseUrl(string baseUrl)
    {
        _client.BaseAddress = new Uri(baseUrl);
    }
}