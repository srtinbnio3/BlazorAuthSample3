using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAuthSample3.Client;
using BlazorAuthSample3.Client.Services;
using BlazorAuthSample3.Client.Util;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorAuthSample3.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddHttpClient<PublicHttpClient>("BlazorAuthSample3.ServerAPI.AnonymousAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAuthSample3.ServerAPI"));

builder.Services.AddScoped<IPublicProductService, PublicProductService>();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://srtinbnio3.onmicrosoft.com/df21e91d-9495-4538-b81c-9682f959e424/API.Access");
    options.ProviderOptions.LoginMode = "redirect";
});

await builder.Build().RunAsync();
