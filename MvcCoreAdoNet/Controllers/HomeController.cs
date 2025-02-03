using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
//using MvcCoreEmpty.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GatitoSection()
        {
            return View();
        }

        public IActionResult VistaCoche()
        {
            Coche coche = new Coche();
            coche.Marca = "Kia";
            coche.Tipo = "SUV";
            coche.Year = 2025;
            return View(coche);
        }
    }
}
