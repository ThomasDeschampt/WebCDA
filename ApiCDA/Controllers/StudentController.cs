using BusinessLayer;
using Castle.Windsor;
using IBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.Extensions.Logging;

namespace ApiCDA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
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

        private readonly IStudentBL _context;
        private readonly ILogger<StudentsController> _logger;

        // Injection des dépendances via le constructeur
        public StudentsController(ILogger<StudentsController> logger, IStudentBL context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = _context.GetEleves();
            return Ok(students);
        }

        // GET: Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.GetEleve(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: Students
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                await _context.CreateEleve(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateEleve(student);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _context.DeleteEleve(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: Students/Find
        [HttpPost("find")]
        public async Task<ActionResult<Student>> FindStudent(string nom)
        {
            try
            {
                var student = await _context.FindEleve(nom);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
