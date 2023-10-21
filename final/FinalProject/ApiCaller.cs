using System;
using System.Net.Http.Headers;

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

    public abstract Task Lookup();
}