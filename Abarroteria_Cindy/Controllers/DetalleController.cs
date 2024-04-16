using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Abarroteria_Cindy.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> _logger;
        private AbarroteriaBdContext _context;

        public DetalleController(ILogger<DetalleController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
       {
        var detalle = _context.Detalle_Factura.Where(w => w.Eliminado == false).ProjectToType<DetalleVm>().ToList();
            return View(detalle);
        }





        [HttpGet]
        public IActionResult Insertar(Guid encabezadoId)
        {
            ViewBag.EncabezadoId = encabezadoId;

            var productos = _context.Producto.Select(p => new {
                Id_Producto = p.Id_Producto,
                Nombre = p.Nombre,
                Precio_Normal = p.Precio_Normal,
                Precio_Mayorista = p.Precio_Mayorista
            }).ToList();

            ViewBag.Productos = productos;

            return View();
        }

        [HttpPost]

        public IActionResult Insertar(DetalleVm detalle)
        {
            

            Console.WriteLine("El ID del producto es___________--------: " + detalle.Id_Producto);
            Console.WriteLine(detalle.Id_Producto);


            // Validar si el encabezado existe
            var encabezado = _context.Encabezado_Factura.FirstOrDefault(e => e.Id_Encabezado_factura == detalle.Id_Encabezado_Factura);
            if (encabezado == null)
            {
                return NotFound("No se encontró el encabezado de factura asociado.");
            }

            // Validar si el producto existe
            var producto = _context.Producto.FirstOrDefault(p => p.Id_Producto == detalle.Id_Producto);
            if (producto == null)
            {
                return NotFound("No se encontró el producto asociado.");
            }

            // Obtener el precio del producto
            var precio = producto.Precio_Normal;

            // Calcular el total de línea
            var totalLinea = detalle.Cantidad * precio;

            // Crear el nuevo detalle de factura
            var nuevoDetalle = new Detalle_Factura
            {
                Id_Detalle_Factura = Guid.NewGuid(),
                Cantidad = detalle.Cantidad,
                
                Total_Linea = totalLinea,
                Id_Encabezado_Factura = detalle.Id_Encabezado_Factura,
                Id_Producto = detalle.Id_Producto
                


             
            };
           

            // Agregar el nuevo detalle al contexto y guardar los cambios en la base de datos
            _context.Detalle_Factura.Add(nuevoDetalle);
            _context.SaveChanges();

            

            TempData["mensaje"] = "Registrado Correctamente";

            // Redirigir al método de pago con el ID del encabezado
            return RedirectToAction("Insertar", new { encabezadoId = detalle.Id_Encabezado_Factura });
        }

        [HttpGet]
        public IActionResult ConfirmarDetalle(Guid encabezadoId)
        {
            var detalles = _context.Detalle_Factura
                .Include(d => d.Producto) // Incluir la entidad Producto
                .Where(d => d.Id_Encabezado_Factura == encabezadoId && !d.Eliminado)
                .Select(d => new DetalleVm
                {
                    Id_Detalle_Factura = d.Id_Detalle_Factura,
                    Cantidad = d.Cantidad,
                    Producto = new ProductoVm // pa que se muestre los nombres y precios de productos
                    {
                        Id_Producto = d.Producto.Id_Producto,
                        Nombre = d.Producto.Nombre,
                        Precio_Normal = d.Producto.Precio_Normal,
                        Precio_Mayorista = d.Producto.Precio_Mayorista
                    },
                    Total_Linea = d.Cantidad > 12 ? d.Producto.Precio_Mayorista * d.Cantidad : d.Producto.Precio_Normal * d.Cantidad,
                    Id_Encabezado_Factura = d.Id_Encabezado_Factura,
                    Id_Producto = d.Id_Producto,
                })
                .ToList();

            ViewBag.EncabezadoId = encabezadoId;
            return View(detalles);
        }



        [HttpGet]
        public IActionResult Editar(Guid Id)
        {
            var detalle = _context.Detalle_Factura.FirstOrDefault(d => d.Id_Detalle_Factura == Id);
            if (detalle == null)
            {
                return NotFound("No se encontró el detalle de factura.");
            }

            // Obtener la lista de productos y convertirla a una lista de SelectListItem
            var productos = _context.Producto.Select(p => new SelectListItem
            {
                Value = p.Id_Producto.ToString(),
                Text = p.Nombre
            }).ToList();

            // Mapear el detalle a un ViewModel si es necesario
            var detalleVm = detalle.Adapt<DetalleVm>();

            // Asignar la lista de productos al ViewBag
            ViewBag.Productos = productos;

            // Cargar datos adicionales necesarios para la vista
            ViewBag.EncabezadoId = detalle.Id_Encabezado_Factura;

            return View(detalleVm);
        }

        [HttpPost]
        public IActionResult Editar(DetalleVm detalleVm)
        {
            var detalle = _context.Detalle_Factura.FirstOrDefault(d => d.Id_Detalle_Factura == detalleVm.Id_Detalle_Factura);
            if (detalle == null)
            {
                return NotFound("No se encontró el detalle de factura.");
            }

            // Actualizar los campos del detalle con los valores del ViewModel
            detalle.Cantidad = detalleVm.Cantidad;
            detalle.Id_Producto = detalleVm.Id_Producto;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            TempData["mensaje"] = "Detalle actualizado correctamente.";

            // Redirigir a la acción ConfirmarDetalle con el ID del encabezado
            return RedirectToAction("ConfirmarDetalle", new { encabezadoId = detalle.Id_Encabezado_Factura });
        }




        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {
            var detalle = _context.Detalle_Factura.FirstOrDefault(d => d.Id_Detalle_Factura == id);
            Guid encabezadoId = Guid.Empty;

            if (detalle != null)
            {
                encabezadoId = detalle.Id_Encabezado_Factura; // Almacenar el ID del encabezado antes de eliminar el detalle
                _context.Detalle_Factura.Remove(detalle);
                _context.SaveChanges();
                TempData["mensaje"] = "Detalle eliminado correctamente.";
                TempData["encabezadoId"] = encabezadoId; // Almacenar el ID del encabezado en TempData
            }

            return RedirectToAction("ConfirmarDetalle", new { encabezadoId = encabezadoId });
        }

        [HttpPost]
        public IActionResult Continuar(Guid encabezadoId)
        {
            // Redirigir al método ConfirmarDetalle con el ID del encabezado
            return RedirectToAction("ConfirmarDetalle", new { encabezadoId = encabezadoId });
        }
       
    }
}
