﻿using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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
        public IActionResult Index()
        {
            var empleado = _context.Empleado.Where(w => w.Eliminado == false).ProjectToType<EmpleadoVm>().ToList(); 
            return View(empleado);
        }
        [HttpGet]
        public IActionResult Insertar()
        {

            EmpleadoVm registros = new EmpleadoVm();
            return View(registros);
        }




        [HttpPost]
        public IActionResult Insertar(EmpleadoVm empleado)
        {
            if (!empleado.Validacion())
            {
                TempData["mensaje"] = "Todos los campos son Obligatorios y verifique la informacion de cada campo";

                return View(empleado);
                //hola este es un comentario
            }
            Empleado nuevoempleado = new Empleado();
            nuevoempleado.Nombre = empleado.Nombre;
            nuevoempleado.Apellido = empleado.Apellido;
            nuevoempleado.Fecha_Nacimiento = empleado.Fecha_Nacimiento;
            nuevoempleado.Telefono = empleado.Telefono;
            nuevoempleado.DNI = empleado.DNI;
            nuevoempleado.Sexo = empleado.Sexo;
            nuevoempleado.Direccion = empleado.Direccion;
            nuevoempleado.Correo = empleado.Correo;
            nuevoempleado.Contraseña = empleado.Contraseña;
            nuevoempleado.RolId = new Guid("56b9180d-3cae-4e61-87db-16cceaf55dc7");
            nuevoempleado.CreatedDate = DateTime.Now;
            nuevoempleado.CreatedBy = Guid.Empty;
            nuevoempleado.Eliminado = false;
            nuevoempleado.Id_Empleado = Guid.NewGuid();

            _context.Empleado.Add(nuevoempleado);
            _context.SaveChanges();
            TempData["mensaje"] = "Registrado Correctamente";

            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Editar(Guid Id_Empleado)
        {
            var registro = _context.Empleado
                                  .Where(w => w.Id_Empleado == Id_Empleado)
                                  .ProjectToType<EmpleadoVm>()
                                  .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
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
            nuevoempleado.Contraseña = empleado.Contraseña;

            _context.SaveChanges();
            TempData["mensaje"] = "Modificado Correctamente";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar(Guid Id_Empleado)
        {

            var registro = _context.Empleado
                                 .Where(w => w.Id_Empleado == Id_Empleado)
                                 .ProjectToType<EmpleadoVm>()
                                 .FirstOrDefault();

            return View(registro);
        }
        [HttpPost]
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
