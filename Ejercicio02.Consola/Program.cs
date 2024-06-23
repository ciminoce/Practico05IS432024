


using ConsoleTables;

namespace Ejercicio02.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? opcionSeleccionada;
            int[] velocidades = new int[5];
            do
            {

                Console.Clear();
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Ingresar Velocidades");
                Console.WriteLine("2 - Mostrar Velocidades");
                Console.WriteLine("3 - Datos Estadísticos");
                Console.WriteLine("4 - Marcar Supeiores al Promedio");
                Console.WriteLine("5 - Ordenar Vector");
                Console.Write("Ingrese selección:");
                opcionSeleccionada = Console.ReadLine();
                switch (opcionSeleccionada)
                {
                    case "0":
                        Console.WriteLine("Fin de la Aplicación");
                        return;
                    case "1":
                        IngresarDatos(velocidades);
                        break;
                    case "2":
                        MostrarVelocidades(velocidades);
                        break;
                    case "3":
                        DatosEstadisticos(velocidades);
                        break;
                    case "4":
                        MarcarSuperioresPromedio(velocidades);
                        break;
                    case "5":
                        OrdenarVector(velocidades);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        private static bool EstaVacio(int[] velocidades)=>velocidades.All(x => x == 0);
        private static void OrdenarVector(int[] velocidades)
        {
            if (!EstaVacio(velocidades))
            {
                Array.Sort(velocidades);
                MostrarVelocidades(velocidades);

            }
            else
            {
                Console.WriteLine("Array sin Datos!!!");
                EsperarTecla("Presione ENTER para continuar");
            }
        }

        private static void MarcarSuperioresPromedio(int[] velocidades)
        {
            var promedio = velocidades.Average();
            Console.Clear();
            Console.WriteLine("Listado de Velocidades con superiores al promedio");
            Console.WriteLine($"Promedio........: {promedio:N2}");
            var tabla = new ConsoleTable("Pos", "Km", "Millas", "Sup. Promedio");
            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = ConvertirKmMillas(velocidades[i]);
                if (velocidades[i] > promedio)
                {
                    tabla.AddRow(i, velocidades[i], millas, "*");

                }
                else
                {
                    tabla.AddRow(i, velocidades[i], millas,string.Empty);
                }
            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Listado finalizado... Tecla para continuar");

        }

        private static void DatosEstadisticos(int[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Datos Estadísticos del Vector");
            if (!EstaVacio(velocidades))
            {
                var maxVelocidad = velocidades.Max();
                var minVelocicad = velocidades.Min();
                var promVelocidad = velocidades.Average();
                var cantidadInferiorPromedio = velocidades.Count(v => v < promVelocidad);
                Console.WriteLine($"Mayor Velocidad: {maxVelocidad}");
                Console.WriteLine($"Menor Veloclidad: {minVelocicad}");
                Console.WriteLine($"Promedio........: {promVelocidad}");
                Console.WriteLine($"Inferiores al Prom: {cantidadInferiorPromedio}");

            }
            else
            {
                Console.WriteLine("Array sin datos!!!");
            }
            EsperarTecla("Proceso finalizado... tecla para continuar");
        }

        private static void MostrarVelocidades(int[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Listado de Velocidades");
            if (!EstaVacio(velocidades))
            {
                var tabla = new ConsoleTable("Pos", "Km", "Millas");
                for (int i = 0; i < velocidades.Length; i++)
                {
                    var millas = ConvertirKmMillas(velocidades[i]);
                    tabla.AddRow(i, velocidades[i], millas);
                }
                Console.WriteLine(tabla.ToString());

            }
            else
            {
                Console.WriteLine("Array sin datos!!!");
            }
            EsperarTecla("Listado finalizado... Tecla para continuar");
        }

        private static void IngresarDatos(int[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Velocidades al vector");
            for (int i = 0; i < velocidades.Length; i++)
            {
                int velocidad;
                do
                {
                    Console.Write($"Ingrese la {i + 1} velocidad:");
                    if (!int.TryParse(Console.ReadLine(), out velocidad) ||
                        velocidad < 100 || velocidad > 300)
                    {
                        Console.WriteLine("Velocada mal ingresada o fuera de rango [100 -300]");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                velocidades[i] = velocidad;
            }
            EsperarTecla("Ingreso finalizado... Presione tecla para continuar");
        }

        private static void EsperarTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }

        private static double ConvertirKmMillas(int v)
        {
            return v * 0.6214;
        }
    }
}
