using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid.Model
{
    internal class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Population { get; set; }
        public double LandArea { get; set; }
        public double? FertilityRate { get; set; }
        public Continent Continent { get; set; }
        public int ContinentId { get; set; }
        public double? GDP { get; set; }
        public override string ToString()
        {
            return String.Format("{0}: {1} people, {2} km2, {3} GDP, fertility {4}", Name, Population, LandArea, GDP, FertilityRate);
        }
    }
}
