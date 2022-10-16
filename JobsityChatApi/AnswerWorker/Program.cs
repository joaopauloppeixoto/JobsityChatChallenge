// See https://aka.ms/new-console-template for more information
using DTOs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
    while (true)
    {

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<BotMessageDto>(Encoding.UTF8.GetString(body));
            Console.WriteLine(" [x] Received {0}", message);


            var request = WebRequest.CreateHttp("https://localhost:7170/api/");
        //    request.Method = "GET";
        //    request.UserAgent = "RequisicaoWebDemo";
        //    using (var resposta = request.GetResponse())
        //    {
        //        var streamDados = resposta.GetResponseStream();
        //        StreamReader reader = new StreamReader(streamDados);
        //        object objResponse = reader.ReadToEnd();
        //        var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());
        //        Console.WriteLine(post.Id + " " + post.title + " " + post.body);
        //        Console.ReadLine();
        //        streamDados.Close();
        //        resposta.Close();
        //    }
        //    Console.ReadLine();
        //}

            //await MessageService.PostAsync(new NewMessageViewModel()
            //{
            //    ChatroomTitle = message.Source,
            //    Content = message.Content,
            //}, "FINANCIALBOT");
        };
        channel.BasicConsume(queue: "financialAnswer",
                             autoAck: true,
                             consumer: consumer);
    }
}