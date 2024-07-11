using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.MessageHander.Shared.Instances;

public class ServiceBusInstance
{
    
    public readonly string Queue = "vinicera-q1";
    
    public readonly int MaxNumberofMessages = 100;
    
    public string GetServiceBusConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        var configuration = builder.Build();
        
        return configuration["ServiceBusConnectionString"];
    }
    public ServiceBusClient GetServiceBusClient()
    => new ServiceBusClient(GetServiceBusConnectionString());

    public ServiceBusSender GetServiceBusSender(string? queue = null)
        => GetServiceBusClient().CreateSender(queue ?? Queue);
    
}