using System.Collections.Generic;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmergencyCallController : ControllerBase
    {
        IEmergencyCallLogic logic;

        public EmergencyCallController(IEmergencyCallLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<EmergencyCallController>/5
        [HttpPut]
        public void Update([FromBody] EmergencyCall value)
        {
            logic.Update(value);
        }

        // DELETE api/<EmergencyCallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
