using System;
using System.Net.Http.Json;
using BlazorAuthSample3.Shared.Entities;
using BlazorAuthSample3.Client.Util;

namespace BlazorAuthSample3.Client.Services;
public interface IPublicProductService
{
    ValueTask<List<Product>> GetAllAsync();
}
public class PublicProductService : IPublicProductService
{
    private readonly HttpClient httpClient;
    public PublicProductService(PublicHttpClient client)
    => this.httpClient = client.Http;
    public async ValueTask<List<Product>> GetAllAsync()
    {
        var response = await httpClient.GetAsync("api/product");
        return await response.Content.ReadFromJsonAsync<List<Product>>();
    }
}