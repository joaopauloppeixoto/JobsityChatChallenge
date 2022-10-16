using DTOs;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace JobsityApi.Workers;

public class BotWorker : BackgroundService
{
    public IMessageService MessageService { get; set; }
    public BotWorker(IMessageService service)
	{
        MessageService = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "financialAnswer",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                while (!stoppingToken.IsCancellationRequested)
                {

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = JsonSerializer.Deserialize<BotMessageDto>(Encoding.UTF8.GetString(body));
                        Console.WriteLine(" [x] Received {0}", message);
                        await MessageService.PostAsync(new NewMessageViewModel()
                        {
                            ChatroomTitle = message.Source,
                            Content = message.Content,
                        }, "FINANCIALBOT");
                    };
                    channel.BasicConsume(queue: "financialAnswer",
                                         autoAck: true,
                                         consumer: consumer);
                }
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
