using ConsoleTables;

namespace Ejercicio04.Consola
{
    internal class Program
    {
        /// <summary>
        /// Definición de variables globales
        /// </summary>
        const int MaxDias = 7;//variable que define la cantidad de elementos
        //static double[] temperaturas = new double[MaxDias];//array de temperaturas
        //static DateTime[] fechas = new DateTime[MaxDias];//array de fechas
        //static int contador = 0;//contador

        static double[] temperaturas = new[] { 5.0, 10, 12, 13, 15, 9, 17 };
        static DateTime[] fechas = new[]{
                new DateTime(2024,07,7),
                new DateTime(2024,07,8),
                new DateTime(2024,07,9),
                new DateTime(2024,07,10),
                new DateTime(2024,07,11),
                new DateTime(2024,07,12),
                new DateTime(2024,07,13)};//array de fechas]
        static int contador = 6;//contador

        static void Main(string[] args)
        {

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Agregar temperaturas");
                Console.WriteLine("2. Modificar temperatura");
                Console.WriteLine("3. Listar temperaturas");
                Console.WriteLine("4. Estadísticas");
                Console.WriteLine("5. Marcar temperaturas respecto al promedio");
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
                        CompararTemperaturas();
                        break;

                    case 6:
                        OrdenarTemperaturas();
                        break;

                    case 7:
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
        private static DateTime GetDateTime(string mensaje, DateTime? maxValue = null)
        {
            DateTime value;
            DateTime maxDate = maxValue ?? DateTime.Now;

            do
            {
                Console.Write($"{mensaje}");

                if (!DateTime.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Fecha mal ingresada. Vuelva a ingresarlo:");
                }
                else if (value > maxDate)
                {
                    Console.WriteLine($"La fecha ingresada no puede ser mayor que {maxDate}. Vuelva a ingresarlo:");
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
                var promedio = CalcularPromedio();
                Console.WriteLine($"Promedio de temperatura: {promedio.ToString("N1")}°C");

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
            if (VectorVacio())
            {
                for (int contador = 0; contador < temperaturas.Length; contador++)
                {
                    fechas[contador] = GetDateTime("Ingrese la fecha (DD-MM-YYYY): ");
                    temperaturas[contador] =
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
            Console.WriteLine("Modificar Datos Ingresados");
            if (!VectorVacio())
            {
                var tabla = new ConsoleTable("Pos. a Mod.", "Fecha", "Celsius");
                for (var i = 0; i < temperaturas.Length; i++)
                {

                    tabla.AddRow(i, fechas[i], temperaturas[i]);

                }
                Console.WriteLine(tabla.ToString());
                var index = GetIntEntre(
                    "Ingrese el numero de la posicion a modificar:"
                    , 0, temperaturas.Length - 1);
                Console.WriteLine($"Fecha anterior:{fechas[index]}");
                Console.WriteLine($"Temperatura anterior: {temperaturas[index]}");
                temperaturas[index] = GetIntEntre("Ingrese la nueva temperatura:", -10, 24);

                EsperaTecla("Temperatura modificada!!!");

            }
            else
            {
                EsperaTecla("Vector Vacío");
            }

        }

        private static void ListarTemperaturas()
        {

            Console.Clear();
            Console.WriteLine("Listado de Temperaturas ingresadas");
            if (!VectorVacio())
            {
                var tabla = new ConsoleTable("Fecha", "Celsius", "Fahreneit");
                for (int i = 0; i < temperaturas.Length; i++)
                {
                    var fah = ConvertirAFahrenheit(temperaturas[i]);
                    tabla.AddRow(fechas[i].ToShortDateString(),
                        temperaturas[i].ToString("N1").PadLeft(5, ' '), fah.ToString("N2").PadLeft(4, ' '));
                }
                Console.WriteLine(tabla.ToString());
                EsperaTecla("Listado Finalizado");
            }
            else {
                EsperaTecla("Vector Vacío" );
            }

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

        private static double CalcularPromedio()
        {

            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                suma += temperaturas[i];
            }
            return suma / contador;
        }

        private static void CompararTemperaturas()
        {

            Console.Clear();
            Console.WriteLine("Comparar Temperaturas");
            if (!VectorVacio())
            {
                var promedio = CalcularPromedio();
                var tabla = new ConsoleTable($"Temp. Prom:{promedio.ToString("N1")}", "Temperatura", "Fecha", "Respecto al Prom");
                Console.WriteLine("Datos cargado correctamente...");
                for (int i = 0; i < temperaturas.Length; i++)
                {
                    tabla.AddRow("", temperaturas[i], fechas[i],
                        temperaturas[i] > promedio ? "Mayor al Promedio" : "Menor al Promedio");
                }
                Console.WriteLine(tabla.ToString());
                EsperaTecla("Presione una tecla para Continuar...");

            }
            else
            {
                EsperaTecla("Vector Vacío");
            }
        }

        static void OrdenarTemperaturas()
        {
            Console.Clear();
            Console.WriteLine("Listado Ordenado");
            if (!VectorVacio())
            {
                Array.Sort(temperaturas, fechas, 0, contador);
                ListarTemperaturas();
                EsperaTecla("Presione Enter para continuar");

            }
            else
            {
                EsperaTecla("Vector Vacío");
            }

        }

        static double ConvertirAFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
    }
}