using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Abarroteria_Cindy.Filters;
using Newtonsoft.Json;

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
        [ClaimRequirement("Proveedores")]
        public IActionResult Index()
        {
            var proveedor = _context.Proveedor.Where(w => w.Eliminado == false).ProjectToType<ProveedorVm>().ToList();
            return View(proveedor);
        }

        [HttpGet]
        [ClaimRequirement("Proveedores")]
        public IActionResult Insertar()
        {
            var proveedor = new ProveedorVm();
            return View(proveedor);
        }

        [HttpPost]
        [ClaimRequirement("Proveedores")]
        public IActionResult Insertar(ProveedorVm proveedor)
        {
            if (!ModelState.IsValid)
            {
                TempData["mensaje"] = "Todos los campos son obligatorios y deben ser válidos.";
                return View(proveedor);
            }
            var sesionJson = HttpContext.Session.GetString("UsuarioObjeto");
            var base64EncodedBytes = System.Convert.FromBase64String(sesionJson);
            var sesion = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            EmpleadoVm UsuarioObjeto = JsonConvert.DeserializeObject<EmpleadoVm>(sesion);
            var nuevoProveedor = new Proveedor
            {
                Id_Proveedor = Guid.NewGuid(),
                Nombre = proveedor.Nombre,
                Telefono = proveedor.Telefono,
                Correo = proveedor.Correo,
                Direccion = proveedor.Direccion,
                CreatedBy = UsuarioObjeto.Id_Empleado, // Debes establecer el valor correcto para CreatedBy
                CreatedDate = DateTime.Now, // Debes establecer el valor correcto para CreatedDate
                Eliminado = false // Por defecto, no está eliminado
            };

            _context.Proveedor.Add(nuevoProveedor);
            _context.SaveChanges();
            TempData["mensaje"] = "Proveedor registrado correctamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Proveedores")]
        public IActionResult Editar(Guid Id_Proveedor)
        {
            var registro = _context.Proveedor
                                  .Where(w => w.Id_Proveedor == Id_Proveedor)
                                  .ProjectToType<ProveedorVm>()
                                  .FirstOrDefault();

            return View(registro);
        }

        [HttpPost]
        [ClaimRequirement("Proveedores")]
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
        [ClaimRequirement("Proveedores")]
        public IActionResult Eliminar(Guid Id_Proveedor)
        {

            var registro = _context.Proveedor
                                 .Where(w => w.Id_Proveedor == Id_Proveedor)
                                 .ProjectToType<ProveedorVm>()
                                 .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("Proveedores")]
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
