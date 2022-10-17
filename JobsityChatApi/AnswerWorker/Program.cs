// See https://aka.ms/new-console-template for more information
using DTOs;
using Flurl;
using Flurl.Http;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "financialAnswer",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var auth = await "https://localhost:7170/api"
        .AppendPathSegment("Auth/login")
        .PostJsonAsync(new
        {
            Email = "FinancialBot",
            Password = "BotFinancialSecret"
        })
        .ReceiveJson<UserViewModel>();

    while (true)
    {

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<BotMessageDto>(Encoding.UTF8.GetString(body));
            Console.WriteLine(" [x] Received {0}", message);

            await "https://localhost:7170/api"
                .AppendPathSegment("Message")
                .WithOAuthBearerToken(auth.Token)
                .PostJsonAsync(new
                {
                    Content = message?.Content,
                    ChatroomTitle = message?.Source
                })
                .ReceiveJson<UserViewModel>();
        };
        channel.BasicConsume(queue: "financialAnswer",
                             autoAck: true,
                             consumer: consumer);
    }
}