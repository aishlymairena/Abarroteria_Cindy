using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Filters;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Abarroteria_Cindy.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> _logger;
        private AbarroteriaBdContext _context;

        public EmpleadoController(ILogger<EmpleadoController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        [ClaimRequirement("Empleados")]
        public IActionResult Index()
        {
            var empleado = _context.Empleado.Where(w => w.Eliminado == false).ProjectToType<EmpleadoVm>().ToList(); 
            return View(empleado);
        }
        [HttpGet]
        [ClaimRequirement("Empleados")]
        public IActionResult Insertar()
        {

            EmpleadoVm registros = new EmpleadoVm();
            return View(registros);
        }

        [HttpPost]
        [ClaimRequirement("Empleados")]
        public IActionResult Insertar(EmpleadoVm empleado)
        {
            if (!empleado.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son Obligatorios y verifique la informacion de cada campo";
                return View(empleado);
            }

            // Verificar si el correo electrónico ya está en uso
            if (_context.Empleado.Any(e => e.Correo == empleado.Correo))
            {
                TempData["mensaje"] = "El correo electrónico ya está en uso. Por favor, elige otro.";
                return View(empleado);
            }
            if (empleado.Contraseña != empleado.Contraseña2)
            {
                TempData["mensaje"] = "Las contraseñas no coinciden. Por favor, intenta de nuevo.";
                return View(empleado);
            }
            if (empleado.Telefono.ToString().Length != 8)
            {
                TempData["mensaje"] = "El número de teléfono debe tener exactamente 8 dígitos.";
                return View(empleado);
            }

            // Verificar el número de dígitos en el campo de DNI
            if (empleado.DNI.Length != 13)
            {
                TempData["mensaje"] = "El número de DNI debe tener exactamente 13 dígitos.";
                return View(empleado);
            }
            var edadMinima = DateTime.Today.AddYears(-15);
            if (empleado.Fecha_Nacimiento > edadMinima)
            {
                TempData["mensaje"] = "El empleado debe tener al menos 15 años de edad.";
                return View(empleado);
            }
            var sesionJson = HttpContext.Session.GetString("UsuarioObjeto");
            var base64EncodedBytes = System.Convert.FromBase64String(sesionJson);
            var sesion = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            EmpleadoVm UsuarioObjeto = JsonConvert.DeserializeObject<EmpleadoVm>(sesion);
            // Resto del código para insertar el nuevo empleado
            // ...
            Empleado nuevoempleado = new Empleado();
            nuevoempleado.Nombre = empleado.Nombre;
            nuevoempleado.Apellido = empleado.Apellido;
            nuevoempleado.Fecha_Nacimiento = empleado.Fecha_Nacimiento;
            nuevoempleado.Telefono = empleado.Telefono;
            nuevoempleado.DNI = empleado.DNI;
            nuevoempleado.Sexo = empleado.Sexo;
            nuevoempleado.Direccion = empleado.Direccion;
            nuevoempleado.Correo = empleado.Correo;
            nuevoempleado.Contraseña = ObtenerMD5Hash(empleado.Contraseña);
            nuevoempleado.RolId = new Guid("56b9180d-3cae-4e61-87db-16cceaf55dc7");
            nuevoempleado.CreatedDate = DateTime.Now;
            nuevoempleado.CreatedBy = UsuarioObjeto.Id_Empleado;
            nuevoempleado.Eliminado = false;
            nuevoempleado.Id_Empleado = Guid.NewGuid();

            _context.Empleado.Add(nuevoempleado);
            _context.SaveChanges();
            TempData["mensaje"] = "Registrado Correctamente";

            return RedirectToAction("Index");
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
        [HttpGet]
        [ClaimRequirement("Empleados")]
        public IActionResult Editar(Guid Id_Empleado)
        {
            var registro = _context.Empleado
                                  .Where(w => w.Id_Empleado == Id_Empleado)
                                  .ProjectToType<EmpleadoVm>()
                                  .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("Empleados")]
        public IActionResult Editar(EmpleadoVm empleado)
        {
            var nuevoempleado = _context.Empleado.FirstOrDefault(w => w.Id_Empleado == empleado.Id_Empleado);

            nuevoempleado.Nombre = empleado.Nombre;
            nuevoempleado.Apellido = empleado.Apellido;
            nuevoempleado.Fecha_Nacimiento = empleado.Fecha_Nacimiento;
            nuevoempleado.Telefono = empleado.Telefono;
            nuevoempleado.DNI = empleado.DNI;
            nuevoempleado.Sexo = empleado.Sexo;
            nuevoempleado.Direccion = empleado.Direccion;
            nuevoempleado.Correo = empleado.Correo;


            _context.SaveChanges();
            TempData["mensaje"] = "Modificado Correctamente";

            return RedirectToAction("Index");
        }
        [HttpGet]
        [ClaimRequirement("Empleados")]
        public IActionResult Eliminar(Guid Id_Empleado)
        {

            var registro = _context.Empleado
                                 .Where(w => w.Id_Empleado == Id_Empleado)
                                 .ProjectToType<EmpleadoVm>()
                                 .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        [ClaimRequirement("Empleados")]
        public IActionResult Eliminar(EmpleadoVm registros)
        {

            var nuevoregistro = _context.Empleado.Where(w => w.Id_Empleado == registros.Id_Empleado).FirstOrDefault();
            nuevoregistro.Eliminado = true;
            _context.SaveChanges();
            TempData["mensaje"] = "El registro fue eliminado Correctamente";

            return RedirectToAction("Index");
        }

    }
}
