namespace Ejercicio04B.Entidades
{
    public struct Temperatura
    {
        public DateOnly Fecha { get; set; }
        public double Valor { get; set; }
        public Temperatura(DateOnly fecha, double valor)
        {
            Fecha = fecha;
            Valor = valor;

        }
        public double GetFahrenheit() => 1.8 * Valor + 32;
    }

}
