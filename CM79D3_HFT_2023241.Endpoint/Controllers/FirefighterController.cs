using System.Collections.Generic;
using CM79D3_HFT_2023241.Endpoint.Services;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FirefighterController : ControllerBase
    {
        IFirefighterLogic logic;
        IHubContext<SignalRHub> hub;
        public FirefighterController(IFirefighterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        // GET: api/<FirefighterController>
        [HttpGet]
        public IEnumerable<Firefighter> Readall()
        {
            return logic.ReadAll();
        }

        // GET api/<FirefighterController>/5
        [HttpGet("{id}")]
        public Firefighter Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<FirefighterController>
        [HttpPost]
        public void Create([FromBody] Firefighter value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("FirefighterCreated", value);
        }

        // PUT api/<FirefighterController>/5
        [HttpPut]
        public void Update([FromBody] Firefighter value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("FirefighterUpdated", value);
        }

        // DELETE api/<FirefighterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var FFToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("FirefighterDeleted", FFToDelete);
        }
    }
}
