using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

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
            var inventarios = _context.Inventario.ProjectToType<InventarioVm>().ToList();
            return View(inventarios);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var inventario = new InventarioVm();
            ViewBag.Productos = _context.Producto.ToList(); // Obtener productos desde la base de datos
            ViewBag.Proveedores = _context.Proveedor.ToList(); // Obtener proveedores desde la base de datos
            return View(inventario);
        }

        [HttpPost]
        public IActionResult Insertar(InventarioVm inventario)
        {
            if (!inventario.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                ViewBag.Productos = _context.Producto.ToList(); // Recargar productos para mostrar en la vista
                ViewBag.Proveedores = _context.Proveedor.ToList(); // Recargar proveedores para mostrar en la vista
                return View(inventario);
            }

            var nuevoInventario = new Inventario
            {
                Id_Inventario = Guid.NewGuid(),
                Stock_Actual = inventario.Stock_Actual,
                Stock_Minimo = inventario.Stock_Minimo,
                Stock_Maximo = inventario.Stock_Maximo,
                Id_Proveedor = inventario.Id_Proveedor,
                Id_Producto = inventario.Id_Producto,
                CreatedBy = Guid.NewGuid(), // Debes establecer el valor correcto para CreatedBy
                CreatedDate = DateTime.Now, // Debes establecer el valor correcto para CreatedDate
                Eliminado = false // Por defecto, no está eliminado
            };

            _context.Inventario.Add(nuevoInventario);
            _context.SaveChanges();

            TempData["mensaje"] = "Inventario registrado correctamente.";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            var inventario = _context.Inventario.FirstOrDefault(i => i.Id_Inventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            ViewBag.Productos = _context.Producto.ToList(); // Obtener productos desde la base de datos
            ViewBag.Proveedores = _context.Proveedor.ToList(); // Obtener proveedores desde la base de datos

            var inventarioVm = new InventarioVm
            {
                Id_Inventario = inventario.Id_Inventario,
                Stock_Actual = inventario.Stock_Actual,
                Stock_Minimo = inventario.Stock_Minimo,
                Stock_Maximo = inventario.Stock_Maximo,
                Id_Proveedor = inventario.Id_Proveedor,
                Proveedor = inventario.Proveedor.Adapt<ProveedorVm>(),
                Id_Producto = inventario.Id_Producto,
                Producto = inventario.Producto.Adapt<ProductoVm>()
            };

            return View(inventarioVm);
        }

        [HttpPost]
        public IActionResult Editar(InventarioVm inventario)
        {
            if (!inventario.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                ViewBag.Productos = _context.Producto.ToList(); // Recargar productos para mostrar en la vista
                ViewBag.Proveedores = _context.Proveedor.ToList(); // Recargar proveedores para mostrar en la vista
                return View(inventario);
            }

            var inventarioExistente = _context.Inventario.FirstOrDefault(i => i.Id_Inventario == inventario.Id_Inventario);
            if (inventarioExistente == null)
            {
                return NotFound();
            }

            // Actualizar los datos del inventario existente con los datos del ViewModel
            inventarioExistente.Stock_Actual = inventario.Stock_Actual;
            inventarioExistente.Stock_Minimo = inventario.Stock_Minimo;
            inventarioExistente.Stock_Maximo = inventario.Stock_Maximo;
            inventarioExistente.Id_Proveedor = inventario.Id_Proveedor;
            inventarioExistente.Id_Producto = inventario.Id_Producto;

            _context.SaveChanges();

            TempData["mensaje"] = "Inventario actualizado correctamente.";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Eliminar(Guid id)
        {
            var inventario = _context.Inventario.FirstOrDefault(i => i.Id_Inventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            ViewBag.Productos = _context.Producto.ToList(); // Obtener productos desde la base de datos
            ViewBag.Proveedores = _context.Proveedor.ToList(); // Obtener proveedores desde la base de datos

            var inventarioVm = new InventarioVm
            {
                Id_Inventario = inventario.Id_Inventario,
                Stock_Actual = inventario.Stock_Actual,
                Stock_Minimo = inventario.Stock_Minimo,
                Stock_Maximo = inventario.Stock_Maximo,
                Id_Proveedor = inventario.Id_Proveedor,
                Proveedor = inventario.Proveedor.Adapt<ProveedorVm>(),
                Id_Producto = inventario.Id_Producto,
                Producto = inventario.Producto.Adapt<ProductoVm>()
            };

            return View(inventarioVm);
        }

        [HttpPost]
        public IActionResult Eliminar(InventarioVm inventario)
        {
            var inventarioExistente = _context.Inventario.FirstOrDefault(i => i.Id_Inventario == inventario.Id_Inventario);
            if (inventarioExistente == null)
            {
                return NotFound();
            }

            // Eliminar el inventario de la base de datos
            _context.Inventario.Remove(inventarioExistente);
            _context.SaveChanges();

            TempData["mensaje"] = "Inventario eliminado correctamente.";
            return RedirectToAction("Index");
        }
    }
}
