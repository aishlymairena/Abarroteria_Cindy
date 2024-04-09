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

            var productos = _context.Producto.ToList();
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
            return RedirectToAction("Insertar", "Pago", new { encabezadoId = detalle.Id_Encabezado_Factura });//en este detalleConfirmacion que haya una boton por si desea agregar mas productos, si no, el boton de continuar al pago
        }

        [HttpGet]
        public IActionResult DetalleConfirmacion(Guid detalleId)
        {


            // Obtener el detalle de factura por su ID
            var detalle = _context.Detalle_Factura
                .Include(d => d.Producto)
                .FirstOrDefault(d => d.Id_Detalle_Factura == detalleId);

           

            // Mapear el detalle a un ViewModel si es necesario
            var detalleVm = detalle.Adapt<DetalleVm>();

            // Cargar datos adicionales necesarios para la vista (si es necesario)
            
            ViewBag.EncabezadoId = detalle.Id_Encabezado_Factura;

            return View(detalleVm);
        }


        [HttpPost]
        public IActionResult Continuar(Guid encabezadoId)
        {
            // Redirigir al método Insertar de Pago con el ID del encabezado
            return RedirectToAction("Insertar", "Pago", new { encabezadoId = encabezadoId });
        }




        [HttpGet]
        public IActionResult Editar(Guid Id)
        {
            var detalle = _context.Detalle_Factura.FirstOrDefault(d => d.Id_Detalle_Factura == Id);
            if (detalle == null)
            {
                return NotFound("No se encontró el detalle de factura.");
            }

            // Mapear el detalle a un ViewModel si es necesario
            var detalleVm = detalle.Adapt<DetalleVm>();

            // Cargar datos adicionales necesarios para la vista
            ViewBag.EncabezadoId = detalle.Id_Encabezado_Factura;
            ViewBag.Productos = _context.Producto.ToList();

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

            // Redirigir a la acción Index o a cualquier otra acción que desees
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Guid id)
        {
            var detalle = _context.Detalle_Factura.FirstOrDefault(d => d.Id_Detalle_Factura == id);
            if (detalle == null)
            {
                return NotFound("No se encontró el detalle de factura.");
            }

            // Marcar el detalle como eliminado
            detalle.Eliminado = true;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            TempData["mensaje"] = "Detalle eliminado correctamente.";

            // Redirigir a la acción Index o a cualquier otra acción que desees
            return RedirectToAction("Index");
        }
    }
}
