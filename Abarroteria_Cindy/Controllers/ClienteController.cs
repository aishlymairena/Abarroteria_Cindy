using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Abarroteria_Cindy.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private AbarroteriaBdContext _context;

        public ClienteController(ILogger<ClienteController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var cliente = _context.Cliente.Where(w => w.Eliminado == false).ProjectToType<ClienteVm>().ToList();
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Insertar()
        {
            ClienteVm registros = new ClienteVm();
            return View(registros);
        }

        [HttpPost]
        public IActionResult Insertar(ClienteVm cliente)
        {
            if (!cliente.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son Obligatorios y verifique la informacion de cada campo";

                return View(cliente);

            }

            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Nombre = cliente.Nombre;
            nuevoCliente.Apellido = cliente.Apellido;
            nuevoCliente.Fecha_Nacimiento = cliente.Fecha_Nacimiento;
            nuevoCliente.Telefono = cliente.Telefono;
            nuevoCliente.DNI = cliente.DNI;
            nuevoCliente.Sexo = cliente.Sexo;
            nuevoCliente.Direccion = cliente.Direccion;
            nuevoCliente.CreatedDate = DateTime.Now;
            nuevoCliente.CreatedBy = Guid.Empty;
            nuevoCliente.Eliminado = false;
            nuevoCliente.Id_Cliente = Guid.NewGuid();

            _context.Cliente.Add(nuevoCliente);
            _context.SaveChanges();
            TempData["mensaje"] = "Registrado Correctamente";

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Editar(Guid Id_Cliente)
        {
            var registro = _context.Cliente
                                  .Where(w => w.Id_Cliente == Id_Cliente)
                                  .ProjectToType<ClienteVm>()
                                  .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
        public IActionResult Editar(ClienteVm cliente)
        {
            var nuevoCliente = _context.Cliente.FirstOrDefault(w => w.Id_Cliente == cliente.Id_Cliente);

            nuevoCliente.Nombre = cliente.Nombre;
            nuevoCliente.Apellido = cliente.Apellido;
            nuevoCliente.Fecha_Nacimiento = cliente.Fecha_Nacimiento;
            nuevoCliente.Telefono = cliente.Telefono;
            nuevoCliente.DNI = cliente.DNI;
            nuevoCliente.Sexo = cliente.Sexo;
            nuevoCliente.Direccion = cliente.Direccion;


            _context.SaveChanges();
            TempData["mensaje"] = "Modificado Correctamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(Guid Id_Cliente)
        {

            var registro = _context.Cliente
                                 .Where(w => w.Id_Cliente == Id_Cliente)
                                 .ProjectToType<ClienteVm>()
                                 .FirstOrDefault();

            return View(registro);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteVm registros)
        {

            var nuevoregistro = _context.Cliente.Where(w => w.Id_Cliente == registros.Id_Cliente).FirstOrDefault();
            nuevoregistro.Eliminado = true;
            _context.SaveChanges();
            TempData["mensaje"] = "Eliminado Correctamente";

            return RedirectToAction("Index");
        }



    }
}
