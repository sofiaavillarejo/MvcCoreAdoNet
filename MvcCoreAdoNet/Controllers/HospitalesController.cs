using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;
        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
        public IActionResult Details(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.CreateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital ingresado";
            //esto nos lleva a Index.cshtml de nuestro controller hospitalesController
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            //buscamos el hospital por su id y lo devolvemos para pintarlo.
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital modificado";
            return View(hospital);
        }

        public IActionResult Delete (int id)
        {
            this.repo.DeleteHospital(id);
            return RedirectToAction("Index");//lo envio a Index para que lo lea
        }
    }
}
