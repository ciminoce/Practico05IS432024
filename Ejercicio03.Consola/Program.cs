

using ConsoleTables;
using System.Reflection.Metadata.Ecma335;

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
            if (!VectorVacio(personas))
            {
                var tabla = new ConsoleTable("Nombre", "Cant. Letras", "Cant.Voc");
                foreach (var item in personas)
                {
                    tabla.AddRow(item, item.Length, VerCantidadVocales(item));
                }
                Console.WriteLine(tabla.ToString());
                EsperaTecla("Listado de nombres x letra terminado!!!");

            }
            else
            {
                EsperaTecla("No se han ingresado personas todavía!!!");

            }
        }
        /// <summary>
        /// Método para chequear si el vector está vacío
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        private static bool VectorVacio(string[] personas) => personas.All(p => p.Length == 0);
        private static void OrdenarVector(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado Ordenado de Nombres");
            if (!VectorVacio(personas))
            {
                Array.Sort(personas);
                ImprimirListado(personas);
                EsperaTecla("Listado ordenado finalizado");

            }
            else
            {
                EsperaTecla("No se han ingresado personas todavía!!!");
            }
        }
        private static int VerCantidadVocales(string nombre)
        {
            string vocales = "AEIOU";//variable que contiene las vocales
            int cantidadVocales = 0;//contador de vocales
            var letras = nombre.ToArray();//paso el nombre a un array
            //recorro el array y veo si está contenio en vocales
            for (int i = 0; i < letras.Length; i++)
            {
                //if (vocales.Contains(letras[i].ToString().ToUpper()))
                //{
                //    cantidadVocales++;
                //}
                if (vocales.Contains(letras[i].ToString(),StringComparison.OrdinalIgnoreCase))
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
            if (!VectorVacio(personas))
            {
                var tabla = new ConsoleTable("Letra", "Cantidad");
                for (int i = 65; i <= 90; i++)
                {
                    char letra = Convert.ToChar(i);
                    int cantidad = personas
                        .Count(p => p.ToUpper()
                        .StartsWith(letra.ToString()));
                    tabla.AddRow(letra, cantidad);
                }
                Console.WriteLine(tabla.ToString());
                EsperaTecla("Listado por letra finalizado");

            }
            else
            {
                EsperaTecla("No se han ingresado personas todavía!!!");

            }
        }
            private static void ListadoPorLetraInicial(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Letra Inicial");

            if (!VectorVacio(personas))
            {
                string letra = GetString("Ingrese letra:", 1);
                var tabla = new ConsoleTable("Nombre");
                foreach (var item in personas)
                {
                    //if (item.ToUpper().StartsWith(letra.ToUpper()))
                    //{
                    //    tabla.AddRow(item);

                    //}

                    //otra forma!!
                    //StringComparison.OrdinalIgnoreCase=>Ignora las mayúsculas y minúsculas
                    if (item.ToUpper().StartsWith(letra, StringComparison.OrdinalIgnoreCase))
                    {
                        tabla.AddRow(item);

                    }

                }
                Console.WriteLine(tabla.ToString());
                EsperaTecla("Listado de nombres x letra terminado!!!");

            }
            else
            {
                EsperaTecla("No se han ingresado personas todavía!!!");

            }

        }

        private static void ListadoDePersonas(string[] personas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Personas");
            if (!VectorVacio(personas))
            {
                ImprimirListado(personas);
                EsperaTecla("Listado de nombres terminado!!!");

            }
            else
            {
                EsperaTecla("No se han ingresado personas todavía!!!");
            }

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

        private static void IngresarPersonas(string[] personas)
        {
            Console.Clear();
            for (int i = 0; i < personas.Length; i++)
            {

                personas[i] = GetString($"Ingrese el nombre de la {i + 1}° peersona:", 12);

            }
            EsperaTecla("Presione una tecla para Continuar...");
        }

        private static void EsperaTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
        /// <summary>
        /// Método para tomar por consola caracteres
        /// </summary>
        /// <param name="mensaje">Mensaje aclaratorio</param>
        /// <param name="cantidad">Cantidad de caracteres permitidos</param>
        /// <returns></returns>
        private static string GetString(string mensaje, int cantidad)
        {
            string? nombre;
            do
            {
                Console.Write(mensaje);
                nombre = Console.ReadLine();
                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("Debe ingresar un nombre!!!");
                }
                else if (nombre.Length > cantidad)
                {
                    Console.WriteLine($"Debe tener no más de {cantidad} caracteres!!!");
                }
                else
                {
                    break;
                }
            } while (true);
            return nombre;
        }

    }
}
