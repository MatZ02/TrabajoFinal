using System;
using System.Linq;
using System.Web.Mvc;
using TrabajoFinal.Models;

namespace TrabajoFinal.Controllers
{
    public class HuespedController : Controller
    {
        private readonly hotelEntities db = new hotelEntities();

        // GET: Huesped
        public ActionResult Index()
        {
            return View(db.Huespedes.ToList());
        }

        // GET: Muestra el formulario para crear un huésped
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Procesa el formulario y guarda el huésped
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Huespedes nuevoHuesped)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Huespedes.Add(nuevoHuesped);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException?.Message ?? ex.Message);
                }
            }
            return View(nuevoHuesped);
        }
    }
}
