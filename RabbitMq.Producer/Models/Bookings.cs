using System;
namespace RabbitMq.Producer.Models
{
    public class Bookings
    {
        public Bookings()
        {
        }

        public string From { get; set; }

        public string To { get; set; }

        public string Status { get; set; }
    }
}

