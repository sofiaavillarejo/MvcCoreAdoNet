using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctor repo;
        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }
        public async Task<IActionResult> DoctoresEspecialidad()
        {
            List<Doctor> doctores = await this.repo.GetDoctorsAsync();
            List<string> especialidades = await this.repo.GetEspecialidadesAsync();
            ViewData["ESPECIALIDAD"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> DoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctores = await this.repo.GetDoctoresEspecialidadesAsync(especialidad);
            List<string> especialidades = await this.repo.GetEspecialidadesAsync();
            ViewData["ESPECIALIDAD"] = especialidades;
            return View(doctores);
        }
    }
}
