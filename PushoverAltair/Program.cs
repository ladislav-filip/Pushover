using Altairis.Pushover.Client;

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
var client = new PushoverClient(apiToken);

// await SendSimple();
// await SendToGroupDev();
await SendImageToGroupDev();

async Task SendSimple()
{
    var msg = new PushoverMessage(userKey, "Moje zprava")
    {
        Title = "Muj titulek",
        Priority = MessagePriority.High()
    };

    var result = await client.SendMessage(msg);
    Console.WriteLine(result.Status ? "Message sent successfully!" : "Message send failed!");
}

async Task SendToGroupDev()
{
    var msg = new PushoverMessage(groupDevKey, "Zprava skupiny. <b>Varovani</b>")
    {
        Title = "Skupina Dev",
        Priority = MessagePriority.High(),
        Format = MessageFormat.Html,
        Device = groupDevKey
    };
    
    var result = await client.SendMessage(msg);
    Console.WriteLine(result.Status ? "Message sent successfully!" : "Message send failed!");
}

async Task SendImageToGroupDev()
{
    var msg = new PushoverMessage(groupDevKey, "Zprava skupiny. <b>Varovani</b>")
    {
        Title = "Skupina Dev IMG",
        Priority = MessagePriority.High(),
        Format = MessageFormat.Html,
        Device = groupDevKey,
        
    };
    
    var result = await client.SendMessage(msg,attachmentFileName: "image.jpg");
    Console.WriteLine(result.Status ? "Message sent successfully!" : "Message send failed!");
}