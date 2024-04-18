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
            var pagos = _context.Pago.Where(p => !p.Eliminado).ProjectToType<PagoVm>().ToList();
            return View(pagos);
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

            var pagoVm = new PagoVm
            {
                Id_Encabezado_factura = encabezadoId,
                TotalPagar = encabezado.Detalles.Sum(detalle => detalle.Total_Linea),
                Impuesto = encabezado.Detalles.Sum(detalle => detalle.Total_Linea) * 0.15,
                Detalles = encabezado.Detalles.ToList()
            };

            return View(pagoVm);
        }

        [HttpPost]
        public IActionResult Insertar(PagoVm pagoVm)
        {
           
                var encabezado = _context.Encabezado_Factura
                    .Include(e => e.Detalles)
                    .FirstOrDefault(e => e.Id_Encabezado_factura == pagoVm.Id_Encabezado_factura);

                if (encabezado == null)
                {
                    return RedirectToAction("Index", "Encabezado_");
                }

                var totalPagar = encabezado.Detalles.Sum(detalle => detalle.Total_Linea);
                var impuesto = totalPagar * 0.15;
                var totalimp = totalPagar + impuesto;

                if (pagoVm.MontoRecibido < totalimp)
                {
                    ModelState.AddModelError("MontoRecibido", "El monto recibido debe ser mayor o igual al total a pagar más impuesto.");
                    return View(pagoVm);
                }

                var cambio = pagoVm.MontoRecibido - totalimp;

                var pago = new Pago
                {
                    Id = Guid.NewGuid(),
                    Impuesto = impuesto,
                    TotalPagar = totalPagar,
                    MontoRecibido = pagoVm.MontoRecibido,
                    Cambio = cambio,
                    TotalImp = totalimp,
                    Id_Encabezado_Factura = encabezado.Id_Encabezado_factura,
                    NumeroFactura = encabezado.NumeroFactura,
                    CreatedBy = pagoVm.CreatedBy,
                    CreatedDate = DateTime.Now,
                    Eliminado = pagoVm.Eliminado
                };

                // Asignar los valores de impuesto, total más impuesto y cambio al objeto pagoVm
                pagoVm.Impuesto = impuesto;
                pagoVm.TotalImp = totalimp;
                pagoVm.Cambio = cambio;


                _context.Pago.Add(pago);
                _context.SaveChanges();

                TempData["mensaje"] = "Pago registrado correctamente.";

                return RedirectToAction("Index", "Encabezado_", new { encabezadoId = pagoVm.Id_Encabezado_factura });
            }

        

    }
}
