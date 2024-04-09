using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Filters;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        [ClaimRequirement("Productos")]
        public IActionResult Index(string terminoBusqueda)
        {
            var productos = _context.Producto.Where(p => !p.Eliminado);

            if (!string.IsNullOrEmpty(terminoBusqueda))
            {
                productos = productos.Where(p => p.Nombre.Contains(terminoBusqueda));
            }

            var productosVm = productos.ProjectToType<ProductoVm>().ToList();

            return View(productosVm);
        }

        [HttpGet]
        [ClaimRequirement("Productos")]
        public IActionResult Insertar()
        {
            var producto = new ProductoVm();
            ViewBag.Categorias = _context.Categoria.ToList(); // Obtener categorías desde la base de datos
            return View(producto);
        }

        [HttpPost]
        [ClaimRequirement("Productos")]
        public IActionResult Insertar(ProductoVm producto)
        {
            if (!producto.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                ViewBag.Categorias = _context.Categoria.ToList(); // Recargar categorías para mostrar en la vista
                return View(producto);
            }
            var sesionJson = HttpContext.Session.GetString("UsuarioObjeto");
            var base64EncodedBytes = System.Convert.FromBase64String(sesionJson);
            var sesion = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            EmpleadoVm UsuarioObjeto = JsonConvert.DeserializeObject<EmpleadoVm>(sesion);
            var nuevoProducto = new Producto
            {
                Id_Producto = Guid.NewGuid(),
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio_Normal = producto.Precio_Normal,
                Precio_Mayorista = producto.Precio_Mayorista,
                Id_Categoria = producto.Id_Categoria,
                CreatedBy = UsuarioObjeto.Id_Empleado, // Debes establecer el valor correcto para CreatedBy
                CreatedDate = DateTime.Now, // Debes establecer el valor correcto para CreatedDate
                Eliminado = false // Por defecto, no está eliminado
            };

            _context.Producto.Add(nuevoProducto);
            _context.SaveChanges();
            TempData["mensaje"] = "Producto registrado correctamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Productos")]
        public IActionResult Editar(Guid id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.Id_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = _context.Categoria.ToList(); // Obtener categorías desde la base de datos

            var productoVm = new ProductoVm
            {
                Id_Producto = producto.Id_Producto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio_Normal = producto.Precio_Normal,
                Precio_Mayorista = producto.Precio_Mayorista,
                Id_Categoria = producto.Id_Categoria,
            };

            return View(productoVm);
        }

        [HttpPost]
        [ClaimRequirement("Productos")]
        public IActionResult Editar(ProductoVm producto)
        {
            if (!producto.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                ViewBag.Categorias = _context.Categoria.ToList(); // Recargar categorías para mostrar en la vista
                return View(producto);
            }

            var productoExistente = _context.Producto.FirstOrDefault(p => p.Id_Producto == producto.Id_Producto);
            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio_Normal = producto.Precio_Normal;
            productoExistente.Precio_Mayorista = producto.Precio_Mayorista;
            productoExistente.Id_Categoria = producto.Id_Categoria;

            _context.SaveChanges();
            TempData["mensaje"] = "Producto actualizado correctamente.";
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ClaimRequirement("Productos")]
        public IActionResult Eliminar(Guid id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.Id_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Categorias = _context.Categoria.ToList(); // Obtener categorías desde la base de datos

            var productoVm = new ProductoVm
            {
                Id_Producto = producto.Id_Producto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio_Normal = producto.Precio_Normal,
                Precio_Mayorista = producto.Precio_Mayorista,
                Id_Categoria = producto.Id_Categoria,
            };

            return View(productoVm);
        }

        [HttpPost]
        [ClaimRequirement("Productos")]
        public IActionResult Eliminar(ProductoVm producto)
        {
            var productoExistente = _context.Producto.FirstOrDefault(p => p.Id_Producto == producto.Id_Producto);
            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Eliminado = true;
            _context.SaveChanges();
            TempData["mensaje"] = "Producto eliminado correctamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Productos")]
        public IActionResult ObtenerPrecio(Guid productId)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.Id_Producto == productId);
            if (producto != null)
            {
                return Json(producto.Precio_Normal);
            }
            return Json(null);
        }
    }
}
