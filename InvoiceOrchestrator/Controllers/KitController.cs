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
        private readonly IKitRepository _kitRepo;
        private readonly ILogger<KitController> _logger;

        public KitController(ILogger<KitController> logger, IKitRepository kitRepo)
        {
            _logger = logger;
            _kitRepo = kitRepo;
        }

        

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == Guid.Empty )
            {
                return BadRequest();
            }
            var res = await _kitRepo.GetKitById(id);
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