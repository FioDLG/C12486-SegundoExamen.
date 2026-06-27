using GestorDeMembresia.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeMembresia.UI.Controllers
{
    public class MembresiasController : Controller
    {
        private readonly ApiService _apiService;

        public MembresiasController(ApiService apiService)
        {
            _apiService = apiService;
        }

       
        [HttpGet]
        public async Task<IActionResult> Index(string identificacion)
        {
            var membresias = await _apiService.GetMembresiasActivasAsync();

            if (!string.IsNullOrEmpty(identificacion))
            {
                membresias = membresias
                    .Where(m => m.Identificacion.Contains(identificacion))
                    .ToList();
            }

            return View(membresias ?? new List<MembresiaDto>());
        }

         
        [HttpGet]
        public async Task<IActionResult> Registradas(string identificacion)
        {
            var membresias = await _apiService.GetMembresiasRegistradasAsync();

            if (!string.IsNullOrEmpty(identificacion))
            {
                membresias = membresias
                    .Where(m => m.Identificacion.Contains(identificacion))
                    .ToList();
            }

            return View(membresias ?? new List<MembresiaDto>());
        }

        
        [HttpGet]
        public async Task<IActionResult> Vencidas(string identificacion)
        {
            var membresias = await _apiService.GetMembresiasVencidasAsync();

            if (!string.IsNullOrEmpty(identificacion))
            {
                membresias = membresias
                    .Where(m => m.Identificacion.Contains(identificacion))
                    .ToList();
            }

            return View(membresias ?? new List<MembresiaDto>());
        }

        
        [HttpGet]
        public async Task<IActionResult> Detalle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "❌ No se especificó la identificación de la membresía.";
                return RedirectToAction("Index");
            }

            var membresia = await _apiService.GetMembresiaPorIdAsync(id);

            if (membresia == null)
            {
                TempData["Error"] = "❌ No se encontró la membresía.";
                return RedirectToAction("Index");
            }

            return View(membresia);
        }

        
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Agregar(MembresiaDto nuevaMembresia)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "❌ Datos inválidos.";
                return View(nuevaMembresia);
            }

            var resultado = await _apiService.AgregarMembresiaAsync(nuevaMembresia);

            if (resultado)
            {
                TempData["Mensaje"] = "✅ Membresía registrada correctamente.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "❌ Error al registrar la membresía.";
            return View(nuevaMembresia);
        }

        
        [HttpGet]
        public async Task<IActionResult> Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = "❌ No se especificó la identificación de la membresía.";
                return RedirectToAction("Index");
            }

            var membresia = await _apiService.GetMembresiaPorIdAsync(id);

            if (membresia == null)
            {
                TempData["Error"] = "❌ No se encontró la membresía.";
                return RedirectToAction("Index");
            }

            return View(membresia);
        }

        
        [HttpPost]
        public async Task<IActionResult> Editar(MembresiaDto membresiaEditada)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "❌ Datos inválidos.";
                return View(membresiaEditada);
            }

            var resultado = await _apiService.EditarMembresiaAsync(membresiaEditada);

            if (resultado)
            {
                TempData["Mensaje"] = "✅ Membresía editada correctamente.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "❌ Error al editar la membresía.";
            return View(membresiaEditada);
        }
    }
}


