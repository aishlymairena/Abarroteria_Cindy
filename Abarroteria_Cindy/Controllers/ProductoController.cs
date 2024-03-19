using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using System;
using System.Linq;

namespace Abarroteria_Cindy.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly AbarroteriaBdContext _context;

        public ProductoController(ILogger<ProductoController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Producto.Where(p => !p.Eliminado).ProjectToType<ProductoVm>().ToList();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var producto = new ProductoVm();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Insertar(ProductoVm producto)
        {
            if (!ModelState.IsValid)
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                return View(producto);
            }

            var nuevoProducto = new Producto
            {
                Id_Producto = Guid.NewGuid(),
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio_Normal = producto.Precio_Normal,
                Precio_Mayorista = producto.Precio_Mayorista,
                Id_Categoria = producto.Id_Categoria,
                Id_Inventario = producto.Id_Inventario
            };

            _context.Producto.Add(nuevoProducto);
            _context.SaveChanges();
            TempData["mensaje"] = "Producto registrado correctamente.";
            return RedirectToAction("Index");
        }

        
    }
}
