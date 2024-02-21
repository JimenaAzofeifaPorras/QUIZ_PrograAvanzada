using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleadoController : Controller
    {
        IEmpleadoHelper EmpleadoHelper;

        public EmpleadoController(IEmpleadoHelper empleadoHelper)
        {
            EmpleadoHelper = empleadoHelper;
        }


        // GET: EmpleadoController
        public ActionResult Index()
        {
            List<EmpleadoViewModel> lista = EmpleadoHelper.GetEmpleados();
            return View(lista);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            EmpleadoViewModel empleado = EmpleadoHelper.GetEmpleado(id);
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoViewModel empleado)
        {
            try
            {
                EmpleadoHelper.AddEmpleado(empleado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {

            EmpleadoViewModel empleado = EmpleadoHelper.GetEmpleado(id);
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoViewModel empleado)
        {
            try
            {
                EmpleadoHelper.UpdateEmpleado(empleado);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {

            EmpleadoViewModel empleado = EmpleadoHelper.GetEmpleado(id);
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmpleadoViewModel empleado)
        {
            try
            {
                EmpleadoHelper.DeleteEmpleado(empleado.EmpleadoId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}