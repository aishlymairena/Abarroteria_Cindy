using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

            var caiPorDefecto = "CAI123456789"; // CAI por defecto
            var fechaActual = DateTime.Now;
            var numeroFactura = GenerarNumeroFactura(caiPorDefecto);

            var factura = new EncabezadoVm
            {
                Fecha_Emision = fechaActual,
                NumeroFactura = numeroFactura,
                RTN = "RTN123456789" // RTN por defecto
            };

            return View(factura);
        }

        private string GenerarNumeroFactura(string cai)
        {
            var fechaActual = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Concatenar el CAI y la fecha actual
            var concatenacion = cai + fechaActual;

            // Calcular un hash único a partir de la concatenación del CAI y la fecha actual
            var hash = GetHashCode(concatenacion);

            // Tomar los últimos 8 caracteres del hash para obtener el número de factura
            var numeroFactura = hash.Substring(hash.Length - 8);

            return numeroFactura;
        }

        private string GetHashCode(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    

        [HttpPost]
        public IActionResult Insertar(EncabezadoVm factura)
        {
            var listaEmpleados = _context.Empleado.ToList();
            var listaClientes = _context.Cliente.ToList();

            // Verificar si hay datos en las listas antes de pasarlas al ViewBag
            if (listaEmpleados == null)
            {
                listaEmpleados = new List<Empleado>();
            }

            if (listaClientes == null)
            {
                listaClientes = new List<Cliente>();
            }

            ViewBag.EmpleadoList = new SelectList(listaEmpleados, "Id_Empleado", "Nombre");
            ViewBag.ClienteList = new SelectList(listaClientes, "Id_Cliente", "Nombre");

            // Obtener el CAI seleccionado por el usuario
            var caiSeleccionado = _context.CAI.FirstOrDefault(c => c.Id_Cai == factura.Id_Cai);

            if (caiSeleccionado == null)
            {
                // Manejar el caso en que no se seleccione ningún CAI
                ModelState.AddModelError("Id_Cai", "Debe seleccionar un CAI.");
                return View(factura);
            }

            var fechaActual = DateTime.Now;
            var numeroFactura = GenerarNumeroFactura(caiSeleccionado.Cai);

            var nuevoEncabezado = new Encabezado_Factura
            {
                Fecha_Emision = fechaActual,
                NumeroFactura = numeroFactura,
                RTN = "RTN123456789", // RTN por defecto
                Id_Empleado = factura.Id_Empleado,
                Id_Cai = factura.Id_Cai,
                Id_Cliente = factura.Id_Cliente
            };

            _context.Encabezado_Factura.Add(nuevoEncabezado);
            _context.SaveChanges();

            TempData["mensaje"] = "Registrado Correctamente";

            var encabezadoId = nuevoEncabezado.Id_Encabezado_factura;
            return RedirectToAction("Insertar", "Detalle", new { encabezadoId = encabezadoId });
        }
    }
}


