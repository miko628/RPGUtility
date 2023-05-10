using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    class Dice
    {
        //private Random rand;
        /*public Dice()
        {
           // rand = new Random(System.DateTime.Now.Millisecond);
        }*/
        // k20
        // k12
        //k10 z 0
        //k10 z 00
        //k8
        //k6
        //k4
        public static int k100()
        {
            Random rand= new Random(System.DateTime.Now.Millisecond+ System.DateTime.Now.Millisecond);
            return rand.Next(1000, 100000) / 1000;
        }
        public static int k20()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000,20000)/1000;
        }
        public static int k30()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond + System.DateTime.Now.Millisecond);

            return rand.Next(1000, 30000)/1000;
        }
        public static int k12()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 12000)/1000;
        }
        public static int k8()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 8000)/1000;
        }
        public static int k6()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 6000)/1000;
        }
        public static int k4()
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 4000)/1000;
        }
    }
}
