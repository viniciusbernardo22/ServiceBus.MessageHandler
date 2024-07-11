
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using ServiceBus.MessageHander.Shared.Instances;


var builder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

var configuration = builder.Build();

var instance = new ServiceBusInstance();
var sender = instance.GetServiceBusSender();

using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
    for (int i = 1; i <= instance.MaxNumberofMessages; i++)
    {
        if (!batch.TryAddMessage(new ServiceBusMessage($"Message Number {i}")))
        {
            Console.WriteLine($"Message - {i} failed for some reason.");
        }
    }
    try
    {
        await sender.SendMessagesAsync(batch);

        Console.WriteLine("Messages Sent");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception: {e.Message}");
        throw;
    }
    finally
    {
        await sender.DisposeAsync();
    }



