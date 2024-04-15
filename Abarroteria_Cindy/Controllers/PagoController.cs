using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace Abarroteria_Cindy.Controllers
{
    public class PagoController : Controller
    {
        private readonly ILogger<PagoController> _logger;
        private AbarroteriaBdContext _context;

        public PagoController(ILogger<PagoController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pago = _context.Pago.Where(w => w.Eliminado == false).ProjectToType<PagoVm>().ToList();
            return View(pago);
        }





        [HttpGet]
        public IActionResult Insertar(Guid encabezadoId)
        {
            // de aqui obtengo el encabezado de factura asociado al ID proporcionado
            var encabezado = _context.Encabezado_Factura
                .Include(e => e.Detalles)
                .FirstOrDefault(e => e.Id_Encabezado_factura == encabezadoId);

            if (encabezado == null)
            {
                // despues Si no se encuentra el encabezado, redirigir al index de Encabezado_Factura
                return RedirectToAction("Index", "Encabezado_");
            }

            var detalles = _context.Detalle_Factura.Any(d => d.Id_Encabezado_Factura == encabezadoId);
            if (!detalles)
            {
                // Si no existen detalles, redirigir de nuevo a la vista Insertar del DetalleController
                return RedirectToAction("Insertar", "Detalle", new { encabezadoId = encabezadoId });
            }

            // Calcular el total a pagar sumando el total de líneas de los detalles
            var totalPagar = _context.Detalle_Factura.Where(d => d.Id_Encabezado_Factura == encabezadoId).Sum(d => d.Total_Linea);

            // Calcular el impuesto
            var impuesto = totalPagar * 0.15; // Impuesto del 15%

            // Calcular el total a pagar más el impuesto
            var totalImp = totalPagar + impuesto;

            // Crear el ViewModel para el pago
            var pagoVm = new PagoVm
            {
                NumeroFactura = encabezado.NumeroFactura,
                TotalPagar = totalPagar,
                Impuesto = impuesto,
                TotalImp = totalImp
            };
          
            return View(pagoVm);
        }

        [HttpPost]
        public IActionResult Insertar(PagoVm pagoVm)
        {
            // Obtener el encabezado de factura asociado al ID proporcionado
            var encabezado = _context.Encabezado_Factura
                .Include(e => e.Detalles)
                .FirstOrDefault(e => e.Id_Encabezado_factura == pagoVm.Id_Encabezado_Factura);

            if (encabezado == null)
            {
                // Si no se encuentra el encabezado, redirigir al index de Encabezado_Factura
                return RedirectToAction("Index", "Encabezado_");
            }

            // Calcular el total a pagar sumando el total de líneas de los detalles
            var totalPagar = encabezado.Detalles.Sum(d => d.Total_Linea);

            // Calcular el impuesto (por ejemplo, el 15% del total a pagar)
            var impuesto = totalPagar * 0.15;

            // Calcular el total a pagar más el impuesto
            var totalimp = totalPagar + impuesto;

            // Obtener el número de factura del encabezado
            var numeroFactura = encabezado.NumeroFactura;

            // Verificar que el monto recibido sea mayor o igual al total a pagar
            if (pagoVm.MontoRecibido < totalimp)
            {
                ModelState.AddModelError("MontoRecibido", "El monto recibido debe ser mayor o igual al total a pagar más impuesto.");
                return View(pagoVm); // Regresar el ViewModel con los errores de validación a la vista
            }

            // Calcular el cambio
            var cambio = pagoVm.MontoRecibido - totalimp;

            // Crear el objeto Pago con los datos recibidos y los cálculos realizados
            var pago = new Pago
            {
                Id = Guid.NewGuid(),
                NumeroFactura = numeroFactura,
                Impuesto = impuesto,
                TotalPagar = totalPagar,
                MontoRecibido = pagoVm.MontoRecibido,
                Cambio = cambio,
                TotalImp = totalimp
            };

            // Agregar el nuevo pago al contexto y guardar los cambios en la base de datos
            _context.Pago.Add(pago);
            _context.SaveChanges();

            // Redirigir al método Index del controlador Encabezado_
            return RedirectToAction("Index", "Encabezado_");
        }
    }
}