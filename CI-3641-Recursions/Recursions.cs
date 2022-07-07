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
            if (args.Length != 3)
            {
                Console.WriteLine("Numero incorrecto de parametros.");
                return;
            }

            MeasureRuntime(args[0].ToUpper(), int.Parse(args[1]), int.Parse(args[2]));
        }


        /// <summary>
        /// Calcula el tiempo promedio, maximo y minimo de las distintas implementaciones
        /// de la funcion planteada en el proyecto.
        /// 
        /// <para>Modos posibles:</para>
        /// <list type="bullet">
        ///     <item>
        ///         <term>REC</term>
        ///         <description>Recursion normal</description>
        ///     </item>
        ///     <item>
        ///         <term>TAIL</term>
        ///         <description>Recursion de cola</description>
        ///     </item>
        ///     <item>
        ///         <term>ITER</term>
        ///         <description>Iteracion</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="mode">Tipo de funcion a usar</param>
        /// <param name="n">n a calcular de la funcion</param>
        /// <param name="it">Cantidad de iteraciones</param>
        /// <exception cref="ArgumentException">Arrojada al usarse un modo incorrecto</exception>
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

  
        /// <summary>
        /// Implementacion recursiva de la funcion planteada
        /// </summary>
        /// <param name="n">n a calcular</param>
        /// <returns>Valor n de la funcion planteada</returns>
        public static long RecursiveFunc(long n)
        {
            if (0 <= n && n < ALPHA * BETA)
                return n;

            return RecursiveFunc(n - BETA * 1) + RecursiveFunc(n - BETA * 2) +
                RecursiveFunc(n - BETA * 3) + RecursiveFunc(n - BETA * 4) +
                RecursiveFunc(n - BETA * 5) + RecursiveFunc(n - BETA * 6);
        }


        /// <summary>
        /// Implementacion con recursion de cola de la funcion planteada
        /// </summary>
        /// <param name="n">n a calcular</param>
        /// <returns>Valor n de la funcion planteada</returns>
        public static long TailRecursiveFunc(long n)
        {
            /// <summary>
            /// Funcion auxiliar donde ocurre la recursion de cola.
            /// Aca ocurre toda la magia.
            /// </summary>
            /// <param name="c1">Acumulador c1</param>
            /// <param name="c2">Parametro almacenador 2</param>
            /// <param name="c3">Parametro almacenador 3</param>
            /// <param name="c4">Parametro almacenador 4</param>
            /// <param name="c5">Parametro almacenador 5</param>
            /// <param name="c6">Parametro almacenador 6</param>
            /// <param name="i">Control de profundidad de recursion</param>
            /// <returns>Valor n de la funcion planteada</returns>
            long Aux(long c1, long c2, long c3, long c4, long c5, long c6, long i)
            {
                if (i <= 0)
                    return c1;

                return Aux(c1+c2+c3+c4+c5+c6, c1, c2, c3, c4, c5, i - 1);
            }

            if (n < ALPHA * BETA)
                return n;

            long start = n % BETA;
            return Aux(start + BETA * 5, start + BETA * 4, start + BETA * 3, start + BETA * 2, start + BETA, start, (n - (BETA * ALPHA)) / BETA + 1);
        }


        /// <summary>
        /// Implementacion con iteraciones de la funcion planteada
        /// </summary>
        /// <param name="n">n a calcular</param>
        /// <returns>Valor n de la funcion planteada</returns>
        public static long IterativeFunc(long n)
        {
            if (n < ALPHA * BETA)
                return n;

            // Variable auxiliar. Igual que la variable start en la recursion de cola
            long start = n % BETA;

            // Variables que representan cada parametro de la funcion recursiva de cola
            long c1 = start + BETA * 5;
            long c2 = start + BETA * 4;
            long c3 = start + BETA * 3;
            long c4 = start + BETA * 2;
            long c5 = start + BETA;
            long c6 = start;

            // Cada ciclo corresponde a un nivel de recursion de cola.
            // i es igual al parametro i que se utiliza en la recursion de cola
            // para parar la recursion.
            for (long i = (n - (BETA * ALPHA)) / BETA + 1; i > 0; --i)
            {
                // En el cuerpo del ciclo se asignan a las variables los mismos valores
                // que se les asignaria a los parametros de igual nombre en la funcion
                // recursiva de cola
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

            // Se devuelve el mismo parametro/acumulador que se devuelve en
            // la funcion recursiva de cola
            return c1;
        }
    }
}
