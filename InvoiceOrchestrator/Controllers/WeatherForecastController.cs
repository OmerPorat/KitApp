using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvoiceOrchestrator.Controllers
{
    [ApiController]
    [Route("WeatherForecastController")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IInvoiceRepository invoiceRepository)
        {
            _logger = logger;
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public IEnumerable<int> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5);
        }
        
        [HttpPost]
        public OkResult Post()
        {
            _invoiceRepository.AddInvoice(new Invoice(Guid.NewGuid(), "sup", 200));
            return Ok();
        }
    }
}