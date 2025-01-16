using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSwarmAlgorithm
{
    internal class Swarm
    {
        public Swarm(int lower, int upper, int precision, int numberOfParticles, double c1, double c2, double c3)
        {
            n = numberOfParticles;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            array = new Particle[n];
            xArr = new double[n];
            bgy = -2.1;
            minY = 2.1;
            double sum = 0;
            for(int i = 0; i < n; ++i)
            {
                array[i] = new Particle(upper, lower, precision, random.NextDouble(), c1, c2, c3);
                if (array[i].y > bgy)
                {
                    bgx = array[i].x;
                    bgy = array[i].y;
                }
                if (array[i].y < minY) minY = array[i].y;
                sum += array[i].y;
                xArr[i] = array[i].x;
            }
            avgY = sum / n;
        }
        public Swarm(Swarm prev) {
            array = new Particle[n];
            xArr = new double[n];
            double sum = 0;
            minY = 2.1;
            for(int i = 0; i < n; ++i)
            {
                array[i] = new Particle(prev.array[i], bgx);
                if (array[i].y > bgy)
                {
                    bgx = array[i].x;
                    bgy = array[i].y;
                }
                if (array[i].y < minY) minY = array[i].y;
                sum += array[i].y;
                xArr[i] = array[i].x;
            }
            avgY = sum / n;
        }
        public double[] xArr;
        public Particle[] array;
        public double avgY;
        public double minY;

        public static double bgx;
        public static double bgy;
        public static int n;
    }
}
