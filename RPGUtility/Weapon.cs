using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    internal class Weapon:Item
    {
        public Weapon(string name,int quantity,string description):base(name,quantity,description)
        {
          ///  this.name = name;
          //  this.quantity=quantity;
          //  this.description=description;
        }
    }
}
