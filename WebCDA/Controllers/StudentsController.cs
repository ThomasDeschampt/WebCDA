using BusinessLayer;
using Castle.Windsor;
using IBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebCDA.Controllers
{
    public class StudentsController : Controller
    {

        //injection des dépendences en utilisant Castle Windsor-------------------------------------
        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            //enregistrement dans le container
            container.Register(Castle.MicroKernel.Registration.Component.For<IStudentBL>().ImplementedBy<StudentBL>());
            return container;
        }


        //Résolution du service pour l'utilisation
        IStudentBL context = InitDependency().Resolve<IStudentBL>();
        //-------------------------------------------------------------------------


        // GET: StudentsController
        public ActionResult Index()
        {
            return View(context.GetEleves().ToList<Student>());
        }

        // GET: StudentsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var student = await context.GetEleve(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student stu)
        {
            try
            {
                await context.CreateEleve(stu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await context.GetEleve(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student stu)
        {
            try
            {
                await context.UpdateEleve(stu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var student = await context.GetEleve(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await context.DeleteEleve(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Find
        public ActionResult Find()
        {
            return View();
        }

        // POST: StudentsController/Find
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Find(string nom)
        {
            try
            {
                var student = await context.FindEleve(nom);
                if (student == null)
                {
                    return NotFound();
                }
                return View("Details", student);
            }
            catch
            {
                return View();
            }
        }
    }
}
