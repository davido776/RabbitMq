using System;
using Microsoft.AspNetCore.Mvc;
using RabbitMq.Producer.Models;
using RabbitMq.Producer.Services;

namespace RabbitMq.Producer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {

        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer messageProducer;

        public BookingsController(ILogger<BookingsController> logger, IMessageProducer MessageProducer)
        {
            _logger = logger;
            messageProducer = MessageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Bookings booking)
        {

            messageProducer.SendMessage<Bookings>(booking);
            return Ok();
        }
    }
}

