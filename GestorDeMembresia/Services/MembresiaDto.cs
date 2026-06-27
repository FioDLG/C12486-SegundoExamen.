namespace GestorDeMembresia.UI.Services
{
    public class MembresiaDto
    {
        public string Identificacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public decimal PrecioBaseMensual { get; set; }
        public int TipoDePlan { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public int Estado { get; set; }
        public decimal MontoTotal { get; set; }

        public string NombrePlan
        {
            get
            {
                return TipoDePlan switch
                {
                    1 => "Mensual",
                    2 => "Trimestral",
                    3 => "Anual",
                    _ => "Desconocido"
                };
            }
        }
    }
}

