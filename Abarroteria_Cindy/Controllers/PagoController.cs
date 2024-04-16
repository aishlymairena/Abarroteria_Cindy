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
            var encabezado = _context.Encabezado_Factura
                .Include(e => e.Detalles)
                .FirstOrDefault(e => e.Id_Encabezado_factura == encabezadoId);

            if (encabezado == null)
            {
                return RedirectToAction("Index", "Encabezado_");
            }

            var totalPagar = encabezado.Detalles.Sum(detalle => detalle.Total_Linea);
            var impuesto = totalPagar * 0.15;
            var totalImp = totalPagar + impuesto;

            var pagoVm = new PagoVm
            {
                Encabezado_Factura = new EncabezadoVm(), // Inicializar la propiedad Encabezado_Factura
                NumeroFactura = encabezado.NumeroFactura,
                TotalPagar = totalPagar,
                Impuesto = impuesto,
                TotalImp = totalImp,
                Id_Encabezado_Factura = encabezadoId
            };
          
            return View(pagoVm);
        }

        [HttpPost]
        public IActionResult Insertar(PagoVm pagoVm)
        {
            // Obtener el encabezado de factura asociado al ID proporcionado en el objeto PagoVm
            var encabezado = _context.Encabezado_Factura
                .Include(e => e.Detalles)
                .FirstOrDefault(e => e.Id_Encabezado_factura == pagoVm.Id_Encabezado_Factura);

            if (encabezado == null)
            {
                // Si no se encuentra el encabezado, redirigir al index de Encabezado_Factura
                return RedirectToAction("Index", "Encabezado_");
            }

            // Calcular total 
            var totalPagar = encabezado.Detalles.Sum(detalle => detalle.Total_Linea);
            // Calcular impuesto
            var impuesto = totalPagar * 0.15;
            // Calcular total más impuesto
            var totalimp = totalPagar + impuesto;

            // Verificar si el monto recibido es suficiente
            if (pagoVm.MontoRecibido < totalimp)
            {
                ModelState.AddModelError("MontoRecibido", "El monto recibido debe ser mayor o igual al total a pagar más impuesto.");
                return View(pagoVm);
            }

            // Calcular el cambio
            var cambio = pagoVm.MontoRecibido - totalimp;

            // Crear el objeto Pago
            var pago = new Pago
            {
                Id = Guid.NewGuid(),
                NumeroFactura = encabezado.NumeroFactura, // Asignar el número de factura del encabezado
                Impuesto = impuesto,
                TotalPagar = totalPagar,
                MontoRecibido = pagoVm.MontoRecibido,
                Cambio = cambio,
                TotalImp = totalimp,
                Id_Encabezado_Factura = pagoVm.Id_Encabezado_Factura
            };

            // Guardar el pago en la base de datos
            _context.Pago.Add(pago);
            _context.SaveChanges(); // Guardar los cambios en la base de datos

            // Redirigir al index de Encabezado_ con el encabezadoId
            return RedirectToAction("Index", "Encabezado_", new { encabezadoId = pagoVm.Id_Encabezado_Factura });
        }
    }
}
