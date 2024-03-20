using System.Collections.Generic;
using CM79D3_HFT_2023241.Endpoint.Services;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmergencyCallController : ControllerBase
    {
        IEmergencyCallLogic logic;
        IHubContext<SignalRHub> hub;
        public EmergencyCallController(IEmergencyCallLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        // GET: api/<EmergencyCallController>
        [HttpGet]
        public IEnumerable<EmergencyCall> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<EmergencyCallController>/5
        [HttpGet("{id}")]
        public EmergencyCall Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<EmergencyCallController>
        [HttpPost]
        public void Create([FromBody] EmergencyCall value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("EmergencyCallCreated", value);
        }

        // PUT api/<EmergencyCallController>/5
        [HttpPut]
        public void Update([FromBody] EmergencyCall value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("EmergencyCallUpdated", value);
        }

        // DELETE api/<EmergencyCallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ECToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("EmergencyCallDeleted", ECToDelete);
        }
    }
}
