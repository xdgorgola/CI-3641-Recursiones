using System;
using System.Diagnostics;

namespace CI_3641_Recursions
{
    internal class Recursions
    {
        /*
         * Constantes ALPHA y BETA.
         * Calculadas con X = 2, Y = 6, Z = 4
         */
        private const long ALPHA = 6;
        private const long BETA = 3;

        public static void Main(string[] args)
        {
            MeasureRuntime(args[0].ToUpper(), int.Parse(args[1]), int.Parse(args[2]));
        }


        public static void MeasureRuntime(string mode, int n, int it)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            double total = 0.0;

            Console.WriteLine($"{mode} TEST");
            for (int i = 0; i < it; ++i)
            {
                double ms;
                switch (mode)
                {
                    case "REC":
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        RecursiveFunc(n);
                        stopwatch.Stop();
                        ms = stopwatch.Elapsed.TotalMilliseconds;
                        break;
                    case "TAIL":
                        stopwatch = Stopwatch.StartNew();
                        TailRecursiveFunc(n);
                        stopwatch.Stop();
                        ms = stopwatch.Elapsed.TotalMilliseconds;
                        break;
                    case "ITER":
                        stopwatch = Stopwatch.StartNew();
                        IterativeFunc(n);
                        stopwatch.Stop();
                        ms = stopwatch.Elapsed.TotalMilliseconds;
                        break;
                    default:
                        throw new ArgumentException("Modo incorrecto.");
                }
                total += ms;

                if (ms < min)
                    min = ms;

                if (ms > max)
                    max = ms;
            }

            Console.WriteLine($"AVG TIME {total / it}");
            Console.WriteLine($"MIN TIME {min}");
            Console.WriteLine($"MAX TIME {max}");
        }

  
        public static long RecursiveFunc(long n)
        {
            if (0 <= n && n < ALPHA * BETA)
                return n;

            return RecursiveFunc(n - BETA * 1) + RecursiveFunc(n - BETA * 2) +
                RecursiveFunc(n - BETA * 3) + RecursiveFunc(n - BETA * 4) +
                RecursiveFunc(n - BETA * 5) + RecursiveFunc(n - BETA * 6);
        }

        
        public static long TailRecursiveFunc(long n)
        {
            long Aux(long c1, long c2, long c3, long c4, long c5, long c6, long i)
            {
                if (i <= 0)
                    return c1;

                return Aux(c1+c2+c3+c4+c5+c6, c1, c2, c3, c4, c5, i - 1);
            }

            if (n < ALPHA * BETA)
                return n;

            long start = n - BETA * (n / BETA);
            return Aux(start + BETA * 5, start + BETA * 4, start + BETA * 3, start + BETA * 2, start + BETA, start, (n - (BETA * ALPHA)) / BETA + 1);
        }


        public static long IterativeFunc(long n)
        {
            if (n < ALPHA * BETA)
                return n;

            long start = n - BETA * (n / BETA);
            long c1 = start + BETA * 5;
            long c2 = start + BETA * 4;
            long c3 = start + BETA * 3;
            long c4 = start + BETA * 2;
            long c5 = start + BETA;
            long c6 = start;

            for (long i = (n - (BETA * ALPHA)) / BETA + 1; i > 0; --i)
            {
                long tmp, tmp2;

                tmp = c1;
                c1 = c1 + c2 + c3 + c4 + c5 + c6;

                tmp2 = c2;
                c2 = tmp;

                tmp = c3;
                c3 = tmp2;

                tmp2 = c4;
                c4 = tmp;

                tmp = c5;
                c5 = tmp2;
               
                c6 = tmp;
            }

            return c1;
        }
    }
}
