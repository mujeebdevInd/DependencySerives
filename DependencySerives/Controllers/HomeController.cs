using DependencySerives.Interface;
using DependencySerives.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencySerives.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService _ScopedService1;
        private readonly IScopedService _ScopedService2;
        private readonly ITransientService _TransientService1;
        private readonly ITransientService _TransientService2;
        private readonly ISingletonService _SingletonService1;
        private readonly ISingletonService _SingletonService2;

        public HomeController(ILogger<HomeController> logger,
            ITransientService TransientService1, ITransientService TransientService2,
            IScopedService ScopedService1, IScopedService ScopedService2,
            ISingletonService SingletonService1, ISingletonService SingletonService2)
        {
            _logger = logger;
            _TransientService1 = TransientService1;
            _TransientService2 = TransientService2;
            _ScopedService1 = ScopedService1;
            _ScopedService2 = ScopedService2;
            _SingletonService1 = SingletonService1;
            _SingletonService2 = SingletonService2;
        }

        public IActionResult Index()
        {
            ViewBag.Transient1 = _TransientService1.GetGuid().ToString();
            ViewBag.Transient2 = _TransientService2.GetGuid().ToString();

            ViewBag.Scoped1 = _ScopedService1.GetGuid().ToString();
            ViewBag.Scoped2 = _ScopedService2.GetGuid().ToString();

            ViewBag.Singleton1 = _SingletonService1.GetGuid().ToString();
            ViewBag.Singleton2 = _SingletonService2.GetGuid().ToString();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
