using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Filters;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Abarroteria_Cindy.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private AbarroteriaBdContext _context;

        public UsuarioController(ILogger<UsuarioController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(string Codigo)
        {
            if (!string.IsNullOrEmpty(Codigo) && Codigo == "1")
            {
                ViewBag.Error = "Su sesion ha expirado";
                ViewBag.ClaseMensaje = "alert alert-danger alert - dismissable";

            }

            return View();
        }
        [HttpPost]
      
        public IActionResult Index(EmpleadoVm vm)
        {
            var usuario = _context.Empleado.Where(w => w.Eliminado == false & w.Correo == vm.Correo).ProjectToType<EmpleadoVm>().FirstOrDefault();
            if (usuario == null)
            {
                ViewBag.Error = "Usuario o Contraseña inexistentes";
                return View(new EmpleadoVm());
            }
            if (usuario.Contraseña != Utilidades.Utilidades.GetMD5(vm.Contraseña))
            {
                ViewBag.Error = "Usuario o Contraseña inexistentes";
                return View(new EmpleadoVm());
            }

            var modulosroles = _context.ModulosRoles.Where(w => w.Eliminado == false && w.RolId == usuario.Rol.Id).ProjectToType<ModulosRolesVm>().ToList();
            var agrupadosid = modulosroles.Select(s => s.Modulo.AgrupadoModulosId).Distinct().ToList();
            var agrupados = _context.AgrupadoModulos.Where(w => agrupadosid.Contains(w.Id)).ProjectToType<AgrupadoVm>().ToList();

            foreach (var item in agrupados)
            {
                var modulosactuales = modulosroles.Where(w => w.Modulo.AgrupadoModulosId == item.Id).Select(s => s.Modulo.Id).Distinct().ToList();
                item.Modulos = item.Modulos.Where(w => modulosactuales.Contains(w.Id)).ToList();
            }

            usuario.Menu = agrupados;
            var sesionjson = JsonConvert.SerializeObject(usuario);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(sesionjson);
            var sesionbas64 = System.Convert.ToBase64String(plainTextBytes);
            HttpContext.Session.SetString("UsuarioObjeto", sesionbas64);
            return RedirectToAction("Index", "Home");
        }
    }
}
