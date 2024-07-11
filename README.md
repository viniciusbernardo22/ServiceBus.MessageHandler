# ServiceBus.MessageHandler

Este repositório contém uma aplicação de exemplo para processamento de mensagens em tempo real utilizando Azure Service Bus e .NET 6. A aplicação é dividida em três projetos principais:

- **ServiceBus.MessageHandler.Shared**: Contém modelos de dados, configurações e utilitários compartilhados.
- **ServiceBus.MessageHandler.Receiver**: Responsável por receber e processar mensagens do Azure Service Bus.
- **ServiceBus.MessageHandler.Sender**: Responsável por enviar mensagens para o Azure Service Bus.

## Visão Geral

O objetivo deste projeto é demonstrar como utilizar o Azure Service Bus para gerenciar a comunicação entre diferentes partes de uma aplicação distribuída. O Azure Service Bus é ideal para cenários que exigem a entrega confiável de mensagens, como microsserviços, integração de aplicações e arquiteturas baseadas em eventos.

## Recursos Utilizados

- .NET 6
- Azure Service Bus
- .NET User Secrets
