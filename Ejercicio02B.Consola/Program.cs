using ConsoleTables;
using Ejercicio02B.Entidades;

namespace Ejercicio02B.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? opcionSeleccionada;
            Velocidad[] velocidades = new Velocidad[5];
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

        private static void OrdenarVector(Velocidad[] velocidades)
        {
            if (!EstaVacio(velocidades))
            {
                //Array.Sort(velocidades);
                var vectorOrdenado=velocidades.OrderBy(v=>v.Magnitud).ToArray();
                MostrarVelocidades(vectorOrdenado);

            }
            else
            {
                Console.WriteLine("Array sin Datos!!!");
                EsperarTecla("Presione ENTER para continuar");
            }
        }

        private static void MarcarSuperioresPromedio(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Listado de Velocidades con superiores al promedio");
            if (!EstaVacio(velocidades))
            {
                var promedio = velocidades.Average(v => v.Magnitud);
                Console.WriteLine($"Promedio........: {promedio:N2}");
                var tabla = new ConsoleTable("Pos", "Km", "Millas", "Sup. Promedio");
                for (int i = 0; i < velocidades.Length; i++)
                {

                    if (velocidades[i].Magnitud > promedio)
                    {
                        tabla.AddRow(i, velocidades[i],
                            velocidades[i].ConvertirKmMillas().ToString("N2"), "*");

                    }
                    else
                    {
                        tabla.AddRow(i, velocidades[i],
                            velocidades[i].ConvertirKmMillas().ToString("N2"), string.Empty);

                    }
                }
                Console.WriteLine(tabla.ToString());

            }
            else
            {
                Console.WriteLine("Array sin datos!!!!");
            }
            EsperarTecla("Listado finalizado... Tecla para continuar");

        }

        private static void DatosEstadisticos(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Datos Estadísticos del Vector");
            if (!EstaVacio(velocidades))
            {
                var maxVelocidad = velocidades.Max(v => v.Magnitud);
                var minVelocicad = velocidades.Min(v => v.Magnitud);
                var promVelocidad = velocidades.Average(v => v.Magnitud);
                var cantidadInferiorPromedio = velocidades.Count(v => v.Magnitud < promVelocidad);
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

        private static void MostrarVelocidades(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Listado de Velocidades");
            if (!EstaVacio(velocidades))
            {
                var tabla = new ConsoleTable("Pos", "Km", "Millas");
                for (int i = 0; i < velocidades.Length; i++)
                {


                    tabla.AddRow(i, velocidades[i], velocidades[i].ConvertirKmMillas().ToString("N2"));
                }
                Console.WriteLine(tabla.ToString());

            }
            else
            {
                Console.WriteLine("Array sin datos!!!");
            }
            EsperarTecla("Listado finalizado... Tecla para continuar");

        }

        private static bool EstaVacio(Velocidad[] velocidades)
        {
            return velocidades.All(v => v.Magnitud == 0 && v.Escala == null);
        }

        private static void IngresarDatos(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Velocidades al vector");
            for (int i = 0; i < velocidades.Length; i++)
            {
                int velocidadIngresada;
                do
                {
                    Console.Write($"Ingrese la {i + 1} velocidad:");
                    if (!int.TryParse(Console.ReadLine(), out velocidadIngresada) ||
                        velocidadIngresada < 100 || velocidadIngresada > 300)
                    {
                        Console.WriteLine("Velocada mal ingresada o fuera de rango [100 -300]");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                Velocidad velocidad = new Velocidad(velocidadIngresada, "Km.");
                velocidades[i] = velocidad;
            }
            EsperarTecla("Ingreso finalizado... Presione tecla para continuar");
        }
        private static void EsperarTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }


    }
}
