using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    class Dice
    {
        private Random rand;
        public Dice()
        {
            rand = new Random();
        }
        // k20
        // k12
        //k10 z 0
        //k10 z 00
        //k8
        //k6
        //k4
        public int k100()
        {
            return rand.Next(1, 100);
        }
        public int k20()
        { 
            return rand.Next(1,20);
        }
        public int k30()
        {
            return rand.Next(1, 30);
        }
        public int k12()
        {
            return rand.Next(1, 12);
        }
        public int k8()
        {
            return rand.Next(1, 8);
        }
        public int k6()
        {
            return rand.Next(1, 6);
        }
        public int k4()
        {
            return rand.Next(1, 4);
        }
    }
}
