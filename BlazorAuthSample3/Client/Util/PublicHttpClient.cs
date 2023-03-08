using System;
namespace BlazorAuthSample3.Client.Util;
public class PublicHttpClient
{
    public HttpClient Http { get; }
    public PublicHttpClient(HttpClient httpClient)
    => Http = httpClient;
}