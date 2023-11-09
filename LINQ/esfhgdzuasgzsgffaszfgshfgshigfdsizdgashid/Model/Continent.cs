using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esfhgdzuasgzsgffaszfgshfgshigfdsizdgashid.Model
{
    internal class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}
