using System;
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
    public class FireStationController : ControllerBase
    {
        IFireStationLogic logic; 
        IHubContext<SignalRHub> hub;
        public FireStationController(IFireStationLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<FireStation> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public FireStation Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] FireStation value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("FireStationCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] FireStation value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("FireStationUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var FSToDelete = logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("FireStationDeleted", FSToDelete);
        }
    }
}
