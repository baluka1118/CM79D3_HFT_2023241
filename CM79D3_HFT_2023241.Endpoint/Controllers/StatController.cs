using System.Collections;
using System.Collections.Generic;
using CM79D3_HFT_2023241.Models.ClassesForQueries;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CM79D3_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IFireStationLogic fslogic;
        IFirefighterLogic fflogic;

        public StatController(IFireStationLogic fslogic, IFirefighterLogic fflogic)
        {
            this.fslogic = fslogic;
            this.fflogic = fflogic;
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> HowManyFirefightersByStation()
        {
            return fslogic.HowManyFirefightersByStation();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, Dictionary<IncidentType, int>>> EmergencyCallsCountByStationAndType()
        {
            return fslogic.EmergencyCallsCountByStationAndType();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, Dictionary<string, int>>> RankDistribution()
        {
            return fslogic.RankDistribution();
        }

        [HttpGet]
        public IEnumerable<EmergencyCallsBySeasonResult> EmergencyCallsBySeason()
        {
            return fslogic.EmergencyCallsBySeason();
        }

        [HttpGet]
        public IEnumerable<Firefighter> FireFightersWithoutEquipment()
        {
            return fflogic.FireFightersWithoutEquipment();
        }
    }
}
