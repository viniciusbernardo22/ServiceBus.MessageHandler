using Azure.Messaging.ServiceBus;
using ServiceBus.MessageHander.Shared.Instances;

ServiceBusProcessor processor = default!;

var serviceBusInstance = new ServiceBusInstance();

async Task QueueMessageHandler(ProcessMessageEventArgs processMessageEventArgs)
{
    ServiceBusReceivedMessage message = processMessageEventArgs.Message;
    string body = message.Body.ToString();
    Console.WriteLine(body);
    await processMessageEventArgs.CompleteMessageAsync(message);
}

 Task MessageErrorHandler(ProcessErrorEventArgs processMessageEventArgs)
{
    Console.WriteLine(processMessageEventArgs.Exception.ToString());
    return Task.CompletedTask;
}

var client = serviceBusInstance.GetServiceBusClient();
processor = client.CreateProcessor(serviceBusInstance.Queue, new ServiceBusProcessorOptions());

try
{
    processor.ProcessMessageAsync += QueueMessageHandler;
    processor.ProcessErrorAsync += MessageErrorHandler;

    await processor.StartProcessingAsync();
    Console.WriteLine("Press any key to end the processing");
    Console.ReadKey();
    Console.WriteLine("Stopping the receiver...");
    await processor.StopProcessingAsync();
    Console.WriteLine("Stopped receiving Messages");

}
catch (Exception e)
{
    Console.WriteLine($"Error: {e}");
}
finally
{
   await client.DisposeAsync();
   await processor.DisposeAsync();
}