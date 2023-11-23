using System.Collections.Generic;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirefighterController : ControllerBase
    {
        IFirefighterLogic logic;

        public FirefighterController(IFirefighterLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<FirefighterController>/5
        [HttpPut]
        public void Update([FromBody] Firefighter value)
        {
            logic.Update(value);
        }

        // DELETE api/<FirefighterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
