namespace DSWI_T1_Grupo7.Models
{
    public class Motocicleta
    {
        public decimal PrecioOriginal { get; set; } = 6000m;

        public decimal DescuentoMartes { get; set; } = 0.12m;

        public decimal DescuentoSabado { get; set; } = 0.18m;

        public decimal DescuentoFeriado { get; set; } = 0.25m;

        public decimal CalcularPrecio(decimal descuento)
        {
            return PrecioOriginal - (PrecioOriginal * descuento);
        }
    }
}
