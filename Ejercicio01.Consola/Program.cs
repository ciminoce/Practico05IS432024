
using ConsoleTables;
using System.Text;

namespace Ejercicio01.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionSeleccionada;
            int[] numAzar = new int[10];
            do
            {
                Console.Clear();
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Generar Vector");
                Console.WriteLine("2 - Mostrar Vector");
                Console.WriteLine("3 - Estadísticas");
                Console.WriteLine("4 - Ordenar Vector");
                Console.WriteLine("5 - Mostrar Num. Pares");
                Console.WriteLine("6 - Mostrar Num. Primos");
                do
                {
                    Console.Write("Ingrese selección:");
                    if (!int.TryParse(Console.ReadLine(), out opcionSeleccionada))
                    {
                        Console.WriteLine("Opción mal ingresada!!! Reintentar");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                switch (opcionSeleccionada)
                {
                    case 0:
                        break;
                    case 1:
                        GenerarElementosDelVector(numAzar);
                        break;
                    case 2:
                        MostrarVector(numAzar);
                        break;
                    case 3:
                        Estadisticas(numAzar);
                        break;
                    case 4:
                        OrdenarVector(numAzar);
                        break;
                    case 5:
                        MostrarPares(numAzar);
                        break;
                    case 6:
                        MostrarPrimos(numAzar);
                        break;
                    default:
                        break;
                }
                if (opcionSeleccionada==0)
                {
                    Console.WriteLine("Fin de la aplicación");
                    break;
                }
            } while (true);
        }

        private static void MostrarPrimos(int[] numAzar)
        {
            Console.Clear();
            Console.WriteLine("Listado de elementos del vector");
            if (EstaVacio(numAzar))
            {
                Console.WriteLine("Vector vacío!!!");
                Console.WriteLine("Enter para continuar");
                Console.ReadLine();
                return;
            }
            var tabla = new ConsoleTable("Pos.", "Nro", "Primo");
            for (int i = 0; i < numAzar.Length; i++)
            {
                if (EsPrimo(numAzar[i]))
                {
                    tabla.AddRow(i, numAzar[i], "*");

                }
                else
                {
                    tabla.AddRow(i, numAzar[i], string.Empty);

                }
            }
            Console.WriteLine(tabla.ToString());
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();

        }

        private static bool EsPrimo(int v)
        {

            for (int i = 2; i < v / 2; i++)
            {
                if (v%i==0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void MostrarPares(int[] numAzar)
        {
            Console.Clear();
            Console.WriteLine("Listado de elementos del vector");
            if (EstaVacio(numAzar))
            {
                Console.WriteLine("Vector vacío!!!");
                Console.WriteLine("Enter para continuar");
                Console.ReadLine();
                return;
            }
            var tabla = new ConsoleTable("Pos.", "Nro","Nro. Par");
            for (int i = 0; i < numAzar.Length; i++)
            {
                if (EsPar(numAzar[i]))
                {
                    tabla.AddRow(i, numAzar[i],"*");

                }
                else
                {
                    tabla.AddRow(i, numAzar[i], string.Empty);

                }
            }
            Console.WriteLine(tabla.ToString());
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();

        }

        private static bool EsPar(int v)
        {
            return v % 2 == 0;
        }

        private static void OrdenarVector(int[] numAzar)
        {

            Array.Sort(numAzar);
            Console.Clear();
            Console.WriteLine("Vector Ordenado");
            MostrarVector(numAzar);

        }

        private static void Estadisticas(int[] numAzar)
        {
            int menor = numAzar.Min();
            int mayor = numAzar.Max();
            double promedio = numAzar.Average();
            Console.Clear();
            Console.WriteLine("Estadísticas");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Vector de {numAzar.Length} elementos");
            sb.AppendLine($"Menor elemento: {menor}");
            sb.AppendLine($"Mayor elemento: {mayor}");
            sb.AppendLine($"Media de elementos: {promedio}");
            Console.WriteLine(sb.ToString());
            EsperaTecla();

        }

        private static void EsperaTecla()
        {
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }

        private static void MostrarVector(int[] numAzar)
        {
            Console.Clear();
            Console.WriteLine("Listado de elementos del vector");
            if (EstaVacio(numAzar))
            {
                Console.WriteLine("Vector vacío!!!");
                Console.WriteLine("Enter para continuar");
                Console.ReadLine();
                return;
            }
            var tabla = new ConsoleTable("Pos.", "Nro");
            for (int i = 0; i < numAzar.Length; i++)
            {
                tabla.AddRow(i, numAzar[i]);
            }
            Console.WriteLine(tabla.ToString());
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();

        }

        private static bool EstaVacio(int[] numAzar)
        {
            return numAzar.All(x => x == 0);
        }

        private static void GenerarElementosDelVector(int[] numAzar)
        {
            Console.Clear();
            Console.WriteLine("Generando elementos del vector!!!");

            Random r = new Random();
            for (int i = 0; i < numAzar.Length; i++)
            {
                numAzar[i] = r.Next(1, 51);
            }

            Console.WriteLine("Números generados...");
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }
    }
}
