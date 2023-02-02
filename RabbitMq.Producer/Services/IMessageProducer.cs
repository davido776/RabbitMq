using System;
namespace RabbitMq.Producer.Services
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}

