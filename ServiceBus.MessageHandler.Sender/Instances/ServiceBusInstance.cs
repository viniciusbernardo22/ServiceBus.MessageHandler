using Azure.Messaging.ServiceBus;

namespace ServiceBus.MessageHandler.Sender;

public class ServiceBusInstance
{
    private readonly string _connectionString;

    private readonly string _queueOne = "vinicera-q1";
    private readonly string _queueTwo = "vinicera-q2";
    private readonly int _maxNumberofMessages = 3;
    public ServiceBusInstance(string connectionString)
    {
        _connectionString = connectionString;
    }

    private ServiceBusClient GetServiceBusClient()
    => new ServiceBusClient(_connectionString);

    public ServiceBusSender GetServiceBusSender(string? queue = null)
        => GetServiceBusClient().CreateSender(queue ?? _queueOne);

}