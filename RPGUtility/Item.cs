using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPGUtility
{
   public class Item
    {
        public int? id;
        // public string name;
        // public string description;
        public int quantity;

        public BitmapImage image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Item(string name,int quantity,string description)
        {
            this.image = new BitmapImage(new Uri("O:\\programming\\RPGUtility\\RPGUtility\\hnet.com-image.ico", UriKind.RelativeOrAbsolute));
            /*this.image.BeginInit();
            this.image.UriSource=;
            this.image.EndInit();*/
            this.name = name;
            this.quantity = quantity;
            this.description = description;
        }
    }
}
