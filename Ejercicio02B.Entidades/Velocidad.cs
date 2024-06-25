namespace Ejercicio02B.Entidades
{
    public struct Velocidad
    {
        public double Magnitud { get; set; }
        public string Escala { get; set; }
        public Velocidad(double magnitud, string escala) {
            Magnitud = magnitud;
            Escala = escala;
        }
        public double ConvertirKmMillas()
        {
            return Magnitud * 0.6214;
        }
        public override string ToString()
        {
            return $"{Magnitud}";
        }
    }
}
