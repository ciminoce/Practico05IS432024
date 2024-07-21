using ConsoleTables;
using System.Text;

namespace Ejercicio04.Consola
{
    internal class Program
    {
        const int MaxDias = 7;
        static double[] temperaturas = new double[MaxDias];
        static DateTime[] fechas = new DateTime[MaxDias];
        static int contador = 0;
        static void Main(string[] args)
        {

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Agregar temperatura");
                Console.WriteLine("2. Modificar temperatura");
                Console.WriteLine("3. Listar temperaturas");
                Console.WriteLine("4. Estadísticas");
                Console.WriteLine("5. Marcar temperaturas superiores al promedio");
                Console.WriteLine("6. Ordenar temperaturas");
                Console.WriteLine("7. Salir");
                int opcion = GetIntEntre("Seleccione una opción: ", 1, 7);

                switch (opcion)
                {
                    case 1:
                        AgregarTemperatura();
                        break;

                    case 2:
                        ModificarTemperatura();
                        break;

                    case 3:
                        ListarTemperaturas();
                        break;

                    case 4:
                        Estadisticas();
                        break;

                    case 5:
                        MostrarMenorTemperatura();
                        break;

                    case 6:
                        CalcularPromedio();
                        break;

                    case 7:
                        MarcarSuperioresAlPromedio();
                        break;

                    case 8:
                        OrdenarTemperaturas();
                        break;

                    case 9:
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
        private static int GetIntEntre(string mensaje, int minValue, int maxValue)
        {
            int value;
            do
            {
                Console.Write($"{mensaje}");

                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Nro mal ingresado. Vuelva a ingresarlo:");
                }
                else if (value < minValue || value > maxValue)
                {
                    Console.WriteLine($"Nro fuera del rango permitido ({minValue},{maxValue})");

                }
                else
                {
                    break;
                }



            } while (true);
            return value;
        }
        private static DateTime GetDateTime(string mensaje)
        {
            DateTime value;
            do
            {
                Console.Write($"{mensaje}");

                if (!DateTime.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Fecha mal ingresada. Vuelva a ingresarlo:");
                }
                else
                {
                    break;
                }



            } while (true);
            return value;

        }
        private static double GetDoubleEntre(string mensaje, double minValue, double maxValue)
        {
            double value;
            do
            {
                Console.Write($"{mensaje}");

                if (!double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Nro mal ingresado. Vuelva a ingresarlo:");
                }
                else if (value < minValue || value > maxValue)
                {
                    Console.WriteLine($"Nro fuera del rango permitido ({minValue},{maxValue})");

                }
                else
                {
                    break;
                }



            } while (true);
            return value;
        }
        private static void EsperaTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
        private static bool VectorVacio() => contador == 0;
        private static void Estadisticas()
        {
            Console.Clear();
            Console.WriteLine("Datos Estadísticos");
            if (!VectorVacio())
            {
                MostrarMayorTemperatura();
                MostrarMenorTemperatura();
                CalcularPromedio();
                Console.WriteLine("Datos estadisticos cargados...");
                EsperaTecla("Presione una tecla para Continuar...");
            }
            else
            {
                Console.WriteLine("Vector sin datos...");
                EsperaTecla("Presione una tecla para Continuar...");

            }


        }

        private static void AgregarTemperatura()
        {
            Console.Clear();
            Console.WriteLine("Ingreso de temperaturas");
            if (true)
            {
                for (int i = 0; i < temperaturas.Length; i++)
                {
                    fechas[i] = GetDateTime("Ingrese la fecha (YYYY-MM-DD): ");
                    temperaturas[i] =
                        GetDoubleEntre("Ingrese la temperatura en grados Celsius: ", -10, 24);
                }
                EsperaTecla("Operación terminada!!");
            }
            else
            {
                EsperaTecla("Vector lleno!!!");
            }
        }

        static void ModificarTemperatura()
        {
            Console.Clear();
            var tabla = new ConsoleTable("Pos. a Mod.", "Dia semana", "Celsius");
            for (var i = 0; i < temperaturas.Length;)
            {

                    tabla.AddRow(i, fechas[i], temperaturas[i]);

            }
            Console.WriteLine(tabla.ToString());
            var index = GetIntEntre(
                "Ingrese el numero de la pocicion a modificar:"
                , 0, temperaturas.Length - 1);
            Console.WriteLine($"Temperatura anterior: {temperaturas[index]}");
            temperaturas[index] = GetIntEntre("Ingrese la nueva temperatura:", -10, 24);


            Console.WriteLine("Temperatura modificada!!!");
            EsperaTecla("Presione una tecla para Continuar...");

        }

        private static void ListarTemperaturas()
        {

            Console.Clear();
            var tabla = new ConsoleTable("Día semana", "Celsius", "Fahreneit");
            for (int i = 0; i < temperaturas.Length; i++)
            {
                tabla.AddRow(fechas[i], temperaturas[i], ConvertirAFahrenheit(temperaturas[i]));
            }

            Console.WriteLine("Listado completado...");

            Console.WriteLine(tabla.ToString());
            EsperaTecla("Presione una tecla para Continuar...");
        }

        private static void MostrarMayorTemperatura()
        {

            double mayorTemp = temperaturas[0];
            DateTime fechaMayor = fechas[0];
            for (int i = 1; i < contador; i++)
            {
                if (temperaturas[i] > mayorTemp)
                {
                    mayorTemp = temperaturas[i];
                    fechaMayor = fechas[i];
                }
            }
            Console.WriteLine($"Mayor temperatura: {fechaMayor.ToShortDateString()} - {mayorTemp}°C");
        }

        private static void MostrarMenorTemperatura()
        {

            double menorTemp = temperaturas[0];
            DateTime fechaMenor = fechas[0];
            for (int i = 1; i < contador; i++)
            {
                if (temperaturas[i] < menorTemp)
                {
                    menorTemp = temperaturas[i];
                    fechaMenor = fechas[i];
                }
            }
            Console.WriteLine($"Menor temperatura: {fechaMenor.ToShortDateString()} - {menorTemp}°C");
        }

        private static void CalcularPromedio()
        {

            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                suma += temperaturas[i];
            }
            double promedio = suma / contador;
            Console.WriteLine($"Promedio de temperaturas: {promedio}°C");
        }

        private static void MarcarSuperioresAlPromedio()
        {

            Console.Clear();
            var promedio = temperaturas.Average();
            var tabla = new ConsoleTable($"Temp. Prom:{promedio}", "Temperatura", "Fecha", "Mayor. Prom");
            Console.WriteLine("Datos cargado correctamente...");
            for(int i=0;i<temperaturas.Length;i++)
            {
                tabla.AddRow("", temperaturas[i], fechas[i] ,
                    temperaturas[i] > promedio ? "Mayor al Promedio" : "Menor al Promedio");
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Presione una tecla para Continuar...");
        }

        static void OrdenarTemperaturas()
        {
            Array.Sort(temperaturas, fechas, 0, contador);
            Console.WriteLine("Temperaturas ordenadas.");
        }

        static double ConvertirAFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
    }
}