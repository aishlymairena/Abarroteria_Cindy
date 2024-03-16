using Abarroteria_Cindy.Data;
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
            return View();
        }
    }
}
