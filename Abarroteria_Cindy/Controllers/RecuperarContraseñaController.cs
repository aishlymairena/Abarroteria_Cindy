using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Abarroteria_Cindy.Controllers
{
    public class RecuperarContraseñaController : Controller
    {
        private readonly ILogger<RecuperarContraseñaController> _logger;
        private readonly AbarroteriaBdContext _context;

        public RecuperarContraseñaController(ILogger<RecuperarContraseñaController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarCorreoRecuperacion(string correoElectronico)
        {
            // Verificar si el correo electrónico proporcionado está asociado a un usuario
            var usuario = _context.Empleado.FirstOrDefault(e => e.Correo == correoElectronico);

            if (usuario == null)
            {
                // Si el correo electrónico no está asociado a un usuario, mostrar un mensaje de error
                TempData["Error"] = "El correo electrónico proporcionado no está registrado en nuestro sistema.";
                return RedirectToAction("Index");
            }

            // Generar una nueva contraseña aleatoria de 8 caracteres
            string nuevaContraseña = GenerarContraseñaAleatoria(8);

            // Actualizar la contraseña en la base de datos
            usuario.Contraseña = ObtenerMD5Hash(nuevaContraseña);
            _context.SaveChanges();

            // Enviar la nueva contraseña al correo electrónico del usuario utilizando SmtpClient
            await EnviarCorreo(usuario.Correo, "Recuperación de Contraseña", $"Su nueva contraseña es: {nuevaContraseña}");

            TempData["Mensaje"] = "Se ha enviado una nueva contraseña a su correo electrónico.";
            return RedirectToAction("CambiarContraseña", "RecuperarContraseña", new { id = usuario.Id_Empleado });

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

                string contraseñaAnteriorHash = ObtenerMD5Hash(model.ContraseñaAnterior);

                if (empleado.Contraseña != contraseñaAnteriorHash)
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

                empleado.Contraseña = ObtenerMD5Hash(model.NuevaContraseña);

                _context.SaveChanges();

                TempData["mensaje"] = "Contraseña cambiada exitosamente.";
                return RedirectToAction("Index", "Usuario");
            }

            return View(model);
        }

        private string GenerarContraseñaAleatoria(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            return new string(Enumerable.Repeat(caracteresPermitidos, longitud)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string ObtenerMD5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        private async Task EnviarCorreo(string destino, string asunto, string mensaje)
        {
            try
            {
                using (var clienteSmtp = new SmtpClient("smtp.gmail.com"))
                {
                    clienteSmtp.Port = 587;
                    clienteSmtp.UseDefaultCredentials = false;
                    clienteSmtp.Credentials = new NetworkCredential("abarroteriacindy@gmail.com", "ubbm gzcz kmgt darz");
                    clienteSmtp.EnableSsl = true;

                    var correo = new MailMessage("abarroteriacindy@gmail.com", destino, asunto, mensaje);
                    await clienteSmtp.SendMailAsync(correo);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el envío del correo
                TempData["Error"] = "Se produjo un error al enviar el correo electrónico: " + ex.Message;
            }
        }
    }
}
