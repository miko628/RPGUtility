using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    public partial class Stat
    {
        public string name { get; set; }
        public string tooltip { get; set; }
        public int value { get; set; }
        public Stat(string name,string tooltip,int value)
        {
            this.name = name;
            this.tooltip= tooltip;
            this.value = value;
        }
    }
}
