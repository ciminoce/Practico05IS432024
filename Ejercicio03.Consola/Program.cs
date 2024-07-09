

using ConsoleTables;
using System.Net.Http.Headers;

namespace Ejercicio03.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? opcionSeleccionada;
            string[] personas = new string[5];
            do
            {

                Console.Clear();
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Ingresar Personas");
                Console.WriteLine("2 - Mostrar Personas");
                Console.WriteLine("3 - Mostrar Nombres por Letra");
                Console.WriteLine("4 - Estadísticas");
                Console.WriteLine("5 - Ordenar Vector");
                Console.WriteLine("6 - Listado de Nombres con datos");
                Console.Write("Ingrese selección:");
                opcionSeleccionada = Console.ReadLine();
                switch (opcionSeleccionada)
                {
                    case "0":
                        Console.WriteLine("Fin de la Aplicación");
                        return;
                    case "1":
                        IngresarPersonas(personas);
                        break;
                    case "2":
                        ListadoDePersonas(personas);
                        break;
                    case "3":
                        ListadoPorLetraInicial(personas);
                        break;
                    case "4":
                        EstadisticaPorLetra(personas);
                        break;
                    case "5":
                        OrdenarVector(personas);
                        break;
                    case "6":
                        MostrarMasDatos(personas);
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        private static void MostrarMasDatos(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Nombres con Datos Adicionales");
            var tabla = new ConsoleTable("Nombre","Cant. Letras","Cant.Voc");
            foreach (var item in personas)
            {
                tabla.AddRow(item, item.Length,VerCantidadVocales(item));
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Listado de nombres x letra terminado!!!");

        }

        private static void OrdenarVector(string[] personas)
        {
            Array.Sort(personas);
            Console.Clear();
            Console.WriteLine("Listado Ordenado de Nombres");
            ImprimirListado(personas);
            EsperaTecla("Listado ordenado finalizado");
        }
        private static int VerCantidadVocales(string nombre)
        {
            string vocales = "AEIOU";//variable que contiene las vocales
            int cantidadVocales = 0;//contador de vocales
            var letras = nombre.ToArray();//paso el nombre a un array
            //recorro el array y veo si está contenio en vocales
            for (int i = 0; i < letras.Length; i++)
            {
                if (vocales.Contains(letras[i].ToString().ToUpper()))
                {
                    cantidadVocales++;
                }
            }
            return cantidadVocales;
        }

        private static void EstadisticaPorLetra(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Nombres por Letra Inicial");
            var tabla = new ConsoleTable("Letra", "Cantidad");
            for (int i = 65; i <= 90; i++)
            {
                char letra = Convert.ToChar(i);
                int cantidad = personas
                    .Count(p => p.ToUpper()
                    .StartsWith(letra.ToString()));
                tabla.AddRow(letra,cantidad);
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Listado por letra finalizado");
        }

        private static void ListadoPorLetraInicial(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Letra Inicial");
            Console.Write("Ingrese letra:");
            //TODO: Mejorar el control de error acá
            string letra = Console.ReadLine();
            var tabla = new ConsoleTable("Nombre");
            foreach (var item in personas)
            {
                if (item.StartsWith(letra))
                {
                    tabla.AddRow(item);

                }  
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Listado de nombres x letra terminado!!!");


        }

        private static void ListadoDePersonas(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Personas");
            ImprimirListado(personas);
            EsperaTecla("Listado de nombres terminado!!!");

        }

        private static void ImprimirListado(string[] personas)
        {
            var tabla = new ConsoleTable("Nombre");
            foreach (var item in personas)
            {
                tabla.AddRow(item);
            }
            Console.WriteLine(tabla.ToString());
        }

        private static void IngresarPersonas(string[]personas)
        {
            for (int i = 0; i < personas.Length; i++)
            {
                Console.Write($"Ingrese el {i + 1}º nombre:");
                string nombre = Console.ReadLine();
                personas[i] = nombre;

            }
            EsperaTecla("Ingreso de nombres terminado!!!");
        }

        private static void EsperaTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
    }
}
