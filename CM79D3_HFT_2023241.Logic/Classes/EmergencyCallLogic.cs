using CM79D3_HFT_2023241.Logic.ClassesForQueries;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Logic.Classes
{
    public class EmergencyCallLogic : IEmergencyCallLogic
    {
        IRepository<EmergencyCall> repo;
        public EmergencyCallLogic(IRepository<EmergencyCall> repo)
        {
            this.repo = repo;
        }
        public void Create(EmergencyCall item)
        {
            if (item.CallerName == null || item.CallerName.Length > 50 || 
                item?.CallerPhone?.Length > 50 || item.IncidentLocation == null || item.IncidentLocation.Length > 50
                || !Enum.IsDefined(typeof(IncidentType),item.IncidentType) || item.DateTime == DateTime.MinValue 
                || item.FireStation_ID == 0)
            {
                throw new ArgumentException("The EmergencyCall isn't defined correctly.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.Read(id);
            this.repo.Delete(id);
        }

        public EmergencyCall Read(int id)
        {
            var ec = repo.Read(id);
            if (ec == null)
            {
                throw new ArgumentException($"Emergency Call doesn't exist. ({id})");
            }
            return ec;
        }

        public IEnumerable<EmergencyCall> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(EmergencyCall item)
        {
            this.repo.Update(item);
        }
    }
}
