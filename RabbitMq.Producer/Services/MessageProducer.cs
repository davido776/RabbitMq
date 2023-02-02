using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace RabbitMq.Producer.Services
{
    public class MessageProducer : IMessageProducer
    {
        public MessageProducer()
        {
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"    
            };

            var conn = factory.CreateConnection();


            using var channel = conn.CreateModel();

            channel.QueueDeclare("bookings", durable: true, exclusive: true);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("","bookings",body:body);

        }
    }
}

