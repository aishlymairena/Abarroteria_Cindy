using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Abarroteria_Cindy.Controllers
{
    public class CambiarContraseñaController : Controller
    {
        private readonly ILogger<CambiarContraseñaController> _logger;
        private AbarroteriaBdContext _context;

        public CambiarContraseñaController(ILogger<CambiarContraseñaController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult CambiarContraseña(Guid id)
        {
            var viewModel = new CambiarContraseñaVm { Id_Empleado = id };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CambiarContraseña(CambiarContraseñaVm model)
        {
            if (ModelState.IsValid)
            {
                var empleado = _context.Empleado.FirstOrDefault(e => e.Id_Empleado == model.Id_Empleado);

                if (empleado == null)
                {
                    ModelState.AddModelError(string.Empty, "El empleado no existe.");
                    return View(model);
                }

                if (empleado.Contraseña != model.ContraseñaAnterior)
                {
                    ModelState.AddModelError("ContraseñaAnterior", "La contraseña anterior es incorrecta.");
                    return View(model);
                }

                if (model.NuevaContraseña == model.ContraseñaAnterior)
                {
                    ModelState.AddModelError("NuevaContraseña", "La nueva contraseña debe ser diferente a la anterior.");
                    return View(model);
                }

                if (model.NuevaContraseña != model.ConfirmarContraseña)
                {
                    ModelState.AddModelError("ConfirmarContraseña", "Las contraseñas nuevas no coinciden.");
                    return View(model);
                }

                empleado.Contraseña = model.NuevaContraseña;

                _context.SaveChanges();

                TempData["mensaje"] = "Contraseña cambiada exitosamente.";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}
