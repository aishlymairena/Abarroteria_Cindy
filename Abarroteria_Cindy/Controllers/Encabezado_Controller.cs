using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Abarroteria_Cindy.Controllers
{
    public class Encabezado_Controller : Controller
    {
        private readonly ILogger<Encabezado_Controller> _logger;
        private AbarroteriaBdContext _context;

        public Encabezado_Controller(ILogger<Encabezado_Controller> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var factura = _context.Encabezado_Factura.Where(w => w.Eliminado == false).ProjectToType<EncabezadoVm>().ToList();
            return View(factura);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var listaCAI = _context.CAI.ToList();
            var listaEmpleados = _context.Empleado.ToList();
            var listaClientes = _context.Cliente.ToList();

            // Verificar si hay datos en las listas antes de pasarlas al ViewBag
            if (listaCAI == null)
            {
                listaCAI = new List<CAI>();
            }

            if (listaEmpleados == null)
            {
                listaEmpleados = new List<Empleado>();
            }

            if (listaClientes == null)
            {
                listaClientes = new List<Cliente>();
            }

            ViewBag.CAIList = new SelectList(listaCAI, "Id_Cai", "Cai");
            ViewBag.EmpleadoList = new SelectList(listaEmpleados, "Id_Empleado", "Nombre");
            ViewBag.ClienteList = new SelectList(listaClientes, "Id_Cliente", "Nombre");

            var rtnPorDefecto = "AYT87P789HIU5A";
            var fechaActual = DateTime.Now;
            var numeroFactura = $"{fechaActual:yyyyMMdd}-{ObtenerNumeroFactura()}";

            var factura = new EncabezadoVm
            {
                Fecha_Emision = fechaActual,
                NumeroFactura = numeroFactura,
                RTN = rtnPorDefecto

            };

            return View(factura);
        }

        
        private string ObtenerNumeroFactura()
        {
            
            Random rnd = new Random();
            return rnd.Next(1000, 9999).ToString(); // Número aleatorio de 4 dígitos
        }

        [HttpPost]
        public IActionResult Insertar(EncabezadoVm factura)
        {
            var listaCAI = _context.CAI.ToList();
            var listaEmpleados = _context.Empleado.ToList();
            var listaClientes = _context.Cliente.ToList();

            // Verificar si hay datos en las listas antes de pasarlas al ViewBag
            if (listaCAI == null)
            {
                listaCAI = new List<CAI>();
            }

            if (listaEmpleados == null)
            {
                listaEmpleados = new List<Empleado>();
            }

            if (listaClientes == null)
            {
                listaClientes = new List<Cliente>();
            }

            ViewBag.CAIList = new SelectList(listaCAI, "Id_Cai", "Cai");
            ViewBag.EmpleadoList = new SelectList(listaEmpleados, "Id_Empleado", "Nombre");
            ViewBag.ClienteList = new SelectList(listaClientes, "Id_Cliente", "Nombre");

            var rtnPorDefecto = "AYT87P789HIU5A";
            var fechaActual = DateTime.Now;
            var numeroFactura = $"{fechaActual:yyyyMMdd}-{ObtenerNumeroFactura()}";

            var nuevoEncabezado = new Encabezado_Factura
            {
                Fecha_Emision = fechaActual,
                NumeroFactura = numeroFactura,
                RTN = rtnPorDefecto,
                Id_Empleado = factura.Id_Empleado,
                Id_Cai = factura.Id_Cai,
                Id_Cliente = factura.Id_Cliente
            };

            _context.Encabezado_Factura.Add(nuevoEncabezado);
            _context.SaveChanges();

            TempData["mensaje"] = "Registrado Correctamente";

            // ID del encabezado creado
            var encabezadoId = nuevoEncabezado.Id_Encabezado_factura;

            //esto pasa al ID del encabezado a la vista Insertar de Detalle
            return RedirectToAction("Insertar", "Detalle", new { encabezadoId = encabezadoId });
        }


    }
}



