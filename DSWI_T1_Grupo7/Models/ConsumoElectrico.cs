using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo7.Models
{
    public class ConsumoElectrico
    {
        [Required(ErrorMessage = "Ingrese el consumo eléctrico.")]
        [Range(typeof(decimal), "0.01", "1000000",
            ErrorMessage = "El consumo debe ser mayor que cero.")]
        public decimal KwhConsumidos { get; set; }

        public decimal Subtotal { get; private set; }

        public decimal PorcentajeImpuesto { get; private set; }

        public decimal MontoImpuesto { get; private set; }

        public decimal Total { get; private set; }

        public void Calcular()
        {
            decimal primerTramo =
                Math.Min(KwhConsumidos, 100m) * 0.10m;

            decimal segundoTramo =
                Math.Min(Math.Max(KwhConsumidos - 100m, 0m), 150m) * 0.15m;

            decimal tercerTramo =
                Math.Max(KwhConsumidos - 250m, 0m) * 0.22m;

            Subtotal = primerTramo + segundoTramo + tercerTramo;

            PorcentajeImpuesto =
                KwhConsumidos > 500m ? 0.08m : 0.03m;

            MontoImpuesto = Subtotal * PorcentajeImpuesto;

            Total = Subtotal + MontoImpuesto;
        }
    }
}
