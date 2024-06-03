using ExamenMvcConciertosAWSMauricio.Models;
using ExamenMvcConciertosAWSMauricio.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamenMvcConciertosAWSMauricio.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceConciertos service;

        public ConciertosController(ServiceConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            List<CategoriaEvento> categorias = await this.service.GetCategoriaEventoAsync();
            ViewData["CATEGORIAS"] = categorias;
            return View(eventos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<Evento> eventos = await this.service.FindEventosByCategoriaAsync(idcategoria);
            List<CategoriaEvento> categorias = await this.service.GetCategoriaEventoAsync();
            ViewData["CATEGORIAS"] = categorias;
            return View(eventos);
        }
    }
}
