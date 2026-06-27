using GestorDeMembresia.Model;

namespace GestorDeMembresia.BL
{
    public class MembresiaService
    {
        public void CalcularMontoYVencimiento(Membresia membresia)
        {
            switch (membresia.TipoDePlan)
            {
                case 1: // Mensual
                    membresia.MontoTotal = membresia.PrecioBaseMensual;
                    membresia.FechaDeVencimiento = membresia.FechaDeInicio.AddMonths(1);
                    break;

                case 2: // Trimestral
                    membresia.MontoTotal = (membresia.PrecioBaseMensual * 3) * 0.9m;
                    membresia.FechaDeVencimiento = membresia.FechaDeInicio.AddMonths(3);
                    break;

                case 3: // Anual
                    membresia.MontoTotal = (membresia.PrecioBaseMensual * 12) * 0.8m;
                    membresia.FechaDeVencimiento = membresia.FechaDeInicio.AddMonths(12);
                    break;
            }

            membresia.Estado = 1; // Activa
        }
    }
}

