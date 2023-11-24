using System.Collections.Generic;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FireStationController : ControllerBase
    {
        IFireStationLogic logic;

        public FireStationController(IFireStationLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] FireStation value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
