using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSwarmAlgorithm
{
    internal class Particle
    {
        public Particle(int upper, int lower, int precision, double random, double varC1, double varC2, double varC3)
        {
            a = lower;
            b = upper;
            c1 = varC1;
            c2 = varC2;
            c3 = varC3;
            d = precision;
            v = 0;
            x = Math.Round(random * (b - a) - a, d);
            if (x > b) x = b;
            y = ((x % 1) * (Math.Cos(20 * Math.PI * x) - Math.Sin(x)));
            bx = x;
        }
        public Particle(Particle prev, double bg)
        {
            bx = prev.bx;
            by = prev.by;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            double r1 = rnd.NextDouble();
            double r2 = rnd.NextDouble();
            double r3 = rnd.NextDouble();
            // if ((c1 * r1 * prev.v + c2 * r2 * (prev.bx - prev.x) + c3 * r3 * (bg - prev.x) + prev.x) > b) { r1 = 0; r2 = 0; r3 = 0;} 
            v = c1 * r1 * prev.v + c2 * r2 * (prev.bx - prev.x) + c3 * r3 * (bg - prev.x);
            x = Math.Round(prev.x + v, d);
            if (x > b) x = b;
            y = ((x % 1) * (Math.Cos(20 * Math.PI * x) - Math.Sin(x)));

            if (y > prev.by)
            {
                bx = x;
                by = y;
            }
        }

        public double x;
        public double y;
        public double v;
        public double bx;
        public double by;
        public static int a;
        public static int b;
        public static int d;
        public static double c1;
        public static double c2;
        public static double c3;

    }
}
