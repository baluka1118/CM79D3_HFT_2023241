using CM79D3_HFT_2023241.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_HFT_2023241.Models
{
    public static class StaticMethods
    {
        public static string ToStringHelper(object o)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in o.GetType().GetProperties().Where(t => t.GetCustomAttribute<ToStringAttribute>() != null))
            {
                sb.AppendLine($"{item.Name,-25} => {item.GetValue(o)}");
            }

            return sb.ToString();
        }
    }
}
