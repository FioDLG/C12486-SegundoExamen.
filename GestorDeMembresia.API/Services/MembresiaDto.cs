namespace GestorDeMembresia.API.Models
{
    public class MembresiaDto
    {
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public decimal PrecioBaseMensual { get; set; }
        public string TipoDePlan { get; set; } = string.Empty;
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public int Estado { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
