using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.MessageHander.Shared.Instances;

public class ServiceBusInstance
{
    
    private readonly string _queue = "vinicera-q1";
    
    public readonly int MaxNumberofMessages = 3;
    public ServiceBusInstance()
    {
       
    }

    public string GetServiceBusConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        var configuration = builder.Build();
        
        return configuration["ServiceBusConnectionString"];
    }
    private ServiceBusClient GetServiceBusClient()
    => new ServiceBusClient(GetServiceBusConnectionString());

    public ServiceBusSender GetServiceBusSender(string queue = null)
        => GetServiceBusClient().CreateSender(queue ?? _queue);
    
}