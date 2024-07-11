using Azure.Messaging.ServiceBus;

namespace ServiceBus.MessageHander.Shared.Instances;

public class ServiceBusInstance
{
    private readonly string _connectionString;

    private readonly string _queueOne = "vinicera-q1";
    
    public readonly int MaxNumberofMessages = 3;
    public ServiceBusInstance(string connectionString)
    {
        _connectionString = connectionString;
    }

    private ServiceBusClient GetServiceBusClient()
    => new ServiceBusClient(_connectionString);

    public ServiceBusSender GetServiceBusSender()
        => GetServiceBusClient().CreateSender( _queueOne);
    
}