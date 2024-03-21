using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using System;
using System.Linq;
using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Controllers
{
    public class InventarioController : Controller
    {
        private readonly ILogger<InventarioController> _logger;
        private readonly AbarroteriaBdContext _context;

        public InventarioController(ILogger<InventarioController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var inventarios = _context.Inventario.ToList();
            var inventarioViewModels = inventarios.Adapt<List<InventarioVm>>();
            return View(inventarioViewModels);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var inventario = new InventarioVm();
            return View(inventario);
        }

        [HttpPost]
        public IActionResult Insertar(InventarioVm inventario)
        {
            if (!ModelState.IsValid)
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                return View(inventario);
            }

            var nuevoInventario = new Inventario // Cambio aquí: Crear una nueva instancia de Inventario
            {
                Id_Inventario = Guid.NewGuid(),
                Stock_Maximo = inventario.Stock_Maximo
                // Agrega más asignaciones de propiedades si es necesario
            };

            _context.Inventario.Add(nuevoInventario);
            _context.SaveChanges();
            TempData["mensaje"] = "Inventario registrado correctamente.";
            return RedirectToAction("Index");
        }
    }
}



