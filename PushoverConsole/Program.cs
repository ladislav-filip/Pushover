using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Build();

var configure = builder.Configuration;

Console.WriteLine("Start...");

var userKey = configure["Pushover:UserKey"];
var apiToken = configure["Pushover:ApiToken"];
var groupDevKey = configure["Pushover:GroupDevKey"];
var groudFakeKey = configure["Pushover:GroupFakeKey"];

const string url = "https://api.pushover.net/1/messages.json";

await SendPushNotificationAsync("Test zpráva");
return;

async Task SendPushNotificationAsync(string message)
{
    var data = new
    {
        token = apiToken,
        user = userKey,
        message = message
    };

    await SendPostAsync(data);
}

async Task SendPostAsync(object data)
{
    using var client = new HttpClient();
    try
    {
        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Zpráva byla úspěšně odeslána.");
        }
        else
        {
            Console.WriteLine("Odeslání zprávy selhalo. Chybový kód: " + response.StatusCode);
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Nastala chyba při komunikaci s API Pushover: " + e.Message);
    }
}