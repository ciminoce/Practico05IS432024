using ConsoleTables;
using Ejercicio04B.Entidades;

namespace Ejercicio04B.Consola
{
    internal class Program
    {
        const int maxDias = 3;
        static Temperatura[] temperaturas = new Temperatura[]{
            new Temperatura(new DateOnly(2024,07,10),10),
            new Temperatura(new DateOnly(2024,07,11),7.7),
            new Temperatura(new DateOnly(2024,07,12),12),
            };
        static int contador = 3;

        static void Main(string[] args)
        {
            bool continuar = true;
            do
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

                int opcionSeleccionada = GetIntEntre("Ingrese opción [1-7]:", 1, 7);
                switch (opcionSeleccionada)
                {
                    case 1:
                        IngresarTemperaturas();
                        break;
                    case 2:
                        ModificarTemperatura();
                        break;
                    case 3:
                        MostrarArrays();
                        break;
                    case 4:
                        Estadisticas();
                        break;
                    case 5:
                        MarcarTemperaturasRespectoAlPromedio();
                        break;
                    case 6:
                        OrdenarVector();
                        break;
                    default:
                        continuar = false;
                        break;
                }
            }
            while (continuar);
            Console.WriteLine("Fin del Programa");
        }

        private static void OrdenarVector()
        {
            MostrarTitulo("Ordenar Vector");
            if (!EstaVacio())
            {
                Console.WriteLine("1-Ordenar por Temperatura ascendente");
                Console.WriteLine("2-Ordenar por Temperatura descendente");
                Console.WriteLine("3-Ordernar Por Fecha ascendente");
                Console.WriteLine("4-Ordernar Por Fecha descendente");
                int orderBy = GetIntEntre("Ingrese selección:", 1, 4);
                switch (orderBy)
                {
                    case 1:
                        temperaturas = temperaturas.OrderBy(t => t.Valor).ToArray();
                        break;
                    case 2:
                        temperaturas = temperaturas.OrderByDescending(t => t.Valor).ToArray();
                        break;

                    case 3:
                        temperaturas = temperaturas.OrderBy(t => t.Fecha).ToArray();
                        break;
                    case 4:
                        temperaturas = temperaturas.OrderByDescending(t => t.Fecha).ToArray();
                        break;
                }
                MostrarArrays();
            }
            else
            {
                EsperarTecla("Vector sin datos!!!");
            }
        }

        private static void MarcarTemperaturasRespectoAlPromedio()
        {
            MostrarTitulo("Listado de Temperaturas y marca respecto al promedio");
            if (EstaVacio())
            {
                EsperarTecla("Vector sin datos");
                return;
            }
            var promedio = PromedioTemperatura();
            Console.WriteLine($"Promedio de Temperaturas: {promedio.ToString("N1")}");
            var tabla = new ConsoleTable("Pos", "Fecha", "Celsius", "Fahrenheit", "Marca");
            for (int i = 0; i < temperaturas.Length; i++)
            {
                tabla.AddRow(
                            i,
                            temperaturas[i].Fecha,
                            temperaturas[i].Valor.ToString("N1").PadLeft(5, ' '),
                            temperaturas[i].GetFahrenheit().ToString("N2").PadLeft(5, ' '),
                            temperaturas[i].Valor > promedio ? "Mayor al Promedio" : "Menor al Promedio"
                            );
            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Marcas finalizadas");
        }


        private static void MostrarTitulo(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(mensaje);
        }
        private static void EsperarTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
        }
        private static void Estadisticas()
        {
            MostrarTitulo("Datos Estadísticos");
            if (EstaVacio())
            {
                EsperarTecla("Vector sin datos!!!");
                return;
            }
            MostrarMayorTemperatura();
            MostrarMenorTemperatura();
            var promedio = PromedioTemperatura();
            Console.WriteLine($"Promedio de Temperaturas: {(promedio).ToString("N1")}");

            EsperarTecla("Datos estadísticos finalizados");
        }
        private static double PromedioTemperatura()
        {

            return temperaturas.Average(t => t.Valor);
        }

        private static void MostrarMenorTemperatura()
        {
            var minTemp = temperaturas[0].Valor;
            var minFecha = temperaturas[0].Fecha;
            for (int i = 1; i < temperaturas.Length; i++)
            {
                if (temperaturas[i].Valor < minTemp)
                {
                    minTemp = temperaturas[i].Valor;
                    minFecha = temperaturas[i].Fecha;
                }
            }
            Console.WriteLine($"Mínima temperatura: {minTemp} el día {minFecha.ToShortDateString()}");
        }

        private static void MostrarMayorTemperatura()
        {
            var maxTemp = temperaturas[0].Valor;
            var maxFecha = temperaturas[0].Fecha;
            for (int i = 1; i < temperaturas.Length; i++)
            {
                if (temperaturas[i].Valor > maxTemp)
                {
                    maxTemp = temperaturas[i].Valor;
                    maxFecha = temperaturas[i].Fecha;
                }
            }
            Console.WriteLine($"Máxima temperatura: {maxTemp} el día {maxFecha.ToShortDateString()}");
        }

        private static bool EstaVacio() => contador == 0;
        private static void MostrarArrays()
        {
            MostrarTitulo("Listado de Temperaturas");
            if (!EstaVacio())
            {
                MostrarTabla();
                EsperarTecla("Listado finalizado");

            }
            else
            {
                EsperarTecla("Vector sin datos!!");
            }
        }
        private static void ModificarTemperatura()
        {
            MostrarTitulo("Modificación de Temperaturas");
            if (EstaVacio())
            {
                EsperarTecla("Vector sin datos");
                return;
            }
            MostrarTabla();


            int index =
                GetIntEntre(
                    $"Ingrese posición a modificar [0 - {temperaturas.Length - 1}]:", 0,
                    temperaturas.Length - 1);
            Console.WriteLine($"Fecha: {temperaturas[index].Fecha.ToShortDateString()}");
            Console.WriteLine($"Temperatura: {temperaturas[index].Valor}");
            temperaturas[index].Valor = GetDoubleEntre("Ingrese la nueva temperatura [-10,24]:", -10, 24);
            EsperarTecla("Temperatura Modificada!!!");
        }

        private static void MostrarTabla()
        {
            var tabla = new ConsoleTable("Pos.", "Fecha", "Celsius", "Fahrenheit");
            for (int i = 0; i < maxDias; i++)
            {
                tabla.AddRow(i,
                    temperaturas[i].Fecha.ToShortDateString(),
                    temperaturas[i].Valor.ToString().PadLeft(5, ' '),
                    temperaturas[i].GetFahrenheit().ToString("N2").PadLeft(5, ' '));
            }
            Console.WriteLine(tabla.ToString());
        }

        private static void IngresarTemperaturas()
        {
            MostrarTitulo("Ingreso de Temperaturas:");
            if (EstaVacio())
            {
                for (contador = 0; contador < maxDias; contador++)
                {
                    temperaturas[contador].Fecha = GetDateTime("Ingrese la fecha (DD-MM-YYYY):", DateOnly.FromDateTime(DateTime.Today.AddDays(-1)));
                    temperaturas[contador].Valor = GetDoubleEntre("Ingrese la temperatura [-10,24]:", -10, 24);
                    Console.WriteLine($"Equivale a {temperaturas[contador].GetFahrenheit().ToString("N2")}");
                }
                EsperarTecla("Ingreso finalizado");

            }
            else
            {
                EsperarTecla("Vector con datos!!!");
            }

        }

        #region FUNCIONES VARIAS REUTILIZABLES
        private static int GetIntEntre(string mensaje, int minValue, int maxValue)
        {
            int value;
            do
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out value)
                    && (value >= minValue && value <= maxValue))
                {
                    return value;
                }
                Console.WriteLine("Número mal ingresado o fuera de rango");
            } while (true);
        }
        private static DateOnly GetDateTime(string mensaje, DateOnly? dateValue = null)
        {
            DateOnly value;
            DateOnly maxValue = dateValue ?? DateOnly.FromDateTime(DateTime.Now);
            do
            {
                Console.Write(mensaje);
                if (DateOnly.TryParse(Console.ReadLine(), out value)
                    && value <= maxValue)
                {
                    return value;
                }
                Console.WriteLine($"Fecha mal ingresada o fuera de rango, tope {maxValue.ToShortDateString()}");
            } while (true);
        }

        private static double GetDoubleEntre(string mensaje, int minValue, int maxValue)
        {
            double value;
            do
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out value)
                    && (value >= minValue && value <= maxValue))
                {
                    return value;
                }
                Console.WriteLine("Número mal ingresado o fuera de rango");
            } while (true);
        }
        #endregion

    }
}
