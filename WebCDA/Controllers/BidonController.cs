using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCDA.Controllers
{
    public class BidonController : Controller
    {
        // GET: BidonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BidonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BidonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BidonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BidonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BidonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BidonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BidonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
