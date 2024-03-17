using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace Abarroteria_Cindy.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly ILogger<ProveedorController> _logger;
        private readonly AbarroteriaBdContext _context;

        public ProveedorController(ILogger<ProveedorController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var proveedor = _context.Proveedor.Where(w => w.Eliminado == false).ProjectToType<ProveedorVm>().ToList();
            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            var proveedor = new ProveedorVm();
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Insertar(ProveedorVm proveedor)
        {
            if (!ModelState.IsValid)
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                return View(proveedor);
            }

            var nuevoProveedor = new Proveedor
            {
                Id_Proveedor = Guid.NewGuid(),
                Nombre = proveedor.Nombre,
                Telefono = proveedor.Telefono,
                Correo = proveedor.Correo,
                Direccion = proveedor.Direccion
            };

            _context.Proveedor.Add(nuevoProveedor);
            _context.SaveChanges();
            TempData["mensaje"] = "Proveedor registrado correctamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(Guid Id_Proveedor)
        {
            var registro = _context.Proveedor
                                  .Where(w => w.Id_Proveedor == Id_Proveedor)
                                  .ProjectToType<ProveedorVm>()
                                  .FirstOrDefault();

            return View(registro);
        }

        [HttpPost]
        public IActionResult Editar(ProveedorVm proveedor)
        {
            
            var nuevoproveedor = _context.Proveedor.FirstOrDefault(w => w.Id_Proveedor == proveedor.Id_Proveedor);


            nuevoproveedor.Nombre = proveedor.Nombre;
            nuevoproveedor.Telefono = proveedor.Telefono;
            nuevoproveedor.Correo = proveedor.Correo;
            nuevoproveedor.Direccion = proveedor.Direccion;

            _context.SaveChanges();
            TempData["mensaje"] = "Modificado Correctamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(Guid Id_Proveedor)
        {

            var registro = _context.Proveedor
                                 .Where(w => w.Id_Proveedor == Id_Proveedor)
                                 .ProjectToType<ProveedorVm>()
                                 .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        public IActionResult Eliminar(ProveedorVm registros)
        {

            var nuevoregistro = _context.Proveedor.Where(w => w.Id_Proveedor == registros.Id_Proveedor).FirstOrDefault();
            nuevoregistro.Eliminado = true;
            _context.SaveChanges();
            TempData["mensaje"] = "El registro fue eliminado Correctamente";

            return RedirectToAction("Index");
        }
    }
}
