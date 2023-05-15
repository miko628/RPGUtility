using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Random;
namespace RPGUtility
{
    class Dice
    {
        private static MersenneTwister rand=new MersenneTwister();
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
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            //Random rand= new Random(System.DateTime.Now.Millisecond);
            return rand.Next(1000, 101000) / 1000;
        }
        public static int k20()
        {
            int seed = Guid.NewGuid().GetHashCode();
                rand = new MersenneTwister(seed);
            // Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000,21000)/1000;
        }
        public static int k30()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            //Random rand = new Random(System.DateTime.Now.Millisecond );

            return rand.Next(1000, 31000)/1000;
        }
        public static int k10()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            // Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 11000) / 1000;
        }
        public static int k12()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            //Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 13000)/1000;
        }
        public static int k8()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            // Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 9000)/1000;
        }
        public static int k6()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            //Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 7000)/1000;
        }
        public static int k4()
        {
            int seed = Guid.NewGuid().GetHashCode();
            rand = new MersenneTwister(seed);
            //Random rand = new Random(System.DateTime.Now.Millisecond);

            return rand.Next(1000, 5000)/1000;
        }
    }
}
