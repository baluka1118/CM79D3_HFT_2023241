using System.Collections.Generic;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        IEquipmentLogic logic;

        public EquipmentController(IEquipmentLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<EquipmentController>
        [HttpGet]
        public IEnumerable<Equipment> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id}")]
        public Equipment Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<EquipmentController>
        [HttpPost]
        public void Create([FromBody] Equipment value)
        {
            logic.Create(value);
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Equipment value)
        {
            logic.Update(value);
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
