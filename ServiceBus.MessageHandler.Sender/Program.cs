
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using ServiceBus.MessageHandler.Sender;

var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
var configuration = builder.Build();

string serviceBusConnectionString = configuration["ServiceBusConnectionString"];

var instance = new ServiceBusInstance(serviceBusConnectionString);
var sender = instance.GetServiceBusSender();

