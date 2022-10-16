using System;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using System.Text.Json.Serialization;
using System.Text.Json;
using DTOs;
using System.Text.Unicode;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "financialCommand",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

    while (true)
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var objMessage = JsonSerializer.Deserialize<BotMessageDto>(message);
            Console.WriteLine(" [x] Received {0}", objMessage?.Content);

            #region response
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "financialAnswer",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string answer = $"{message}";
                var answerBody = Encoding.UTF8.GetBytes(answer);

                channel.BasicPublish(exchange: "",
                                     routingKey: "financialAnswer",
                                     basicProperties: null,
                                     body: answerBody);
                Console.WriteLine(" [x] Sent {0}", answer);
            }
            #endregion
        };
        channel.BasicConsume(queue: "financialCommand",
                             autoAck: true,
                             consumer: consumer);
        await Task.Delay(1000);
    }
}
