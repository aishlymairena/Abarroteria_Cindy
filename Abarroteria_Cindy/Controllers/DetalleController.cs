using Abarroteria_Cindy.Data;
using Abarroteria_Cindy.Data.Entidades;
using Abarroteria_Cindy.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abarroteria_Cindy.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> _logger;
        private AbarroteriaBdContext _context;

        public DetalleController(ILogger<DetalleController> logger, AbarroteriaBdContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var detalle = _context.Detalle_Factura.Where(w => w.Eliminado == false).ProjectToType<DetalleVm>().ToList();
            return View(detalle);
        }



        [HttpGet]
        public IActionResult Insertar()
        {
            // Obtener la lista de productos desde la base de datos, incluyendo el precio_normal
            var listaProductos = _context.Producto.ToList();

            // Pasar la lista de productos al ViewBag
            ViewBag.ProductList = new SelectList(listaProductos, "Id_Producto", "Nombre", "Precio_Normal");

            return View();
        }

        [HttpPost]
        public IActionResult Insertar(DetalleVm detalle)
        {
            // Crear una instancia de Detalle_Factura y establecer sus propiedades
            var nuevodetalle = new Detalle_Factura
            {
                Cantidad = detalle.Cantidad,
                Total_Linea = detalle.Total_Linea,
                Id_Producto = detalle.Id_Producto
            };

            // Agregar el nuevo detalle al contexto y guardar los cambios
            _context.Detalle_Factura.Add(nuevodetalle);
            _context.SaveChanges();

            TempData["mensaje"] = "Registrado Correctamente";
            return RedirectToAction("Index");
        }
    }
}