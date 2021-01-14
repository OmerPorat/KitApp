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
    [Route("KitController")]
    public class KitController : ControllerBase
    {
        private readonly IInvoiceRepository _kitRepo;
        private readonly ILogger<KitController> _logger;

        public KitController(ILogger<KitController> logger, IInvoiceRepository kitRepo)
        {
            _logger = logger;
            _kitRepo = kitRepo;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> Get(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var res = await _kitRepo.GetKitByName(name);
            return Ok(res);
        }

        [HttpPost]
        public OkResult Post([FromBody] Kit newKit)
        {
            newKit.KitId = Guid.NewGuid();
            _kitRepo.AddKit(newKit);
            return Ok();
        }

        [HttpDelete]
        [Route("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            if (name == null)
            {
                return BadRequest("Name must be specefied");
            }
            var res = await _kitRepo.RemoveKit(name);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Kit newKit)
        {
            var res = await _kitRepo.UpdateKit(newKit);
            return Ok(res);
        }
    } 
}