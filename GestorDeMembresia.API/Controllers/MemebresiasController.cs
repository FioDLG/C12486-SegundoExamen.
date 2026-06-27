using Microsoft.AspNetCore.Mvc;
using GestorDeMembresia.BL;
using GestorDeMembresia.DA;
using GestorDeMembresia.Model;

namespace GestorDeMembresia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembresiasController : ControllerBase
    {
        private readonly GymDbContext _context;
        private readonly MembresiaService _service;

        public MembresiasController(GymDbContext context, MembresiaService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] Membresia membresia, [FromHeader] string apiKey)
        {
            if (apiKey != "1234") 
                return Unauthorized("API Key inválida");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.CalcularMontoYVencimiento(membresia);
            _context.Membresias.Add(membresia);
            _context.SaveChanges();

            return Ok(new { mensaje = "✅ Membresía registrada correctamente", membresia });
        }


        [HttpGet("listar")]
        public IActionResult Listar([FromHeader] string apiKey)
        {
            if (apiKey != "TU_API_KEY") return Unauthorized("API Key inválida");

            return Ok(_context.Membresias.ToList());
        }

        [HttpGet("test-db")]
        public IActionResult TestDatabase()
        {
            try
            {
                // Intenta leer la primera membresía
                var membresia = _context.Membresias.FirstOrDefault();

                if (membresia != null)
                {
                    return Ok(new
                    {
                        Mensaje = "✅ Conexión exitosa a la base de datos Examen2",
                        PrimeraMembresia = new
                        {
                            membresia.Identificacion,
                            membresia.Nombre,
                            membresia.Apellidos,
                            membresia.Estado
                        }
                    });
                }
                else
                {
                    return Ok("✅ Conexión exitosa, pero la tabla Membresias está vacía.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error al conectar con la base de datos: {ex.Message}");
            }
        }

    }
}

