using System;
using RabbitMQ.Client;
using System.Text;
using JobsityApi.Services.Interfaces;
using System.Text.Json;
using DTOs;

namespace JobsityApi.Services;

public class FinancialService : IFinancialService
{
    public async Task SendCommandAsync(string command, string source)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "financialCommand",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = JsonSerializer.Serialize(new BotMessageDto() { Content = command, Source = source });
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "financialCommand",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", command);

        }
    }
}
