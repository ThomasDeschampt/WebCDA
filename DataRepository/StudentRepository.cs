using IDataRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class StudentRepository : IStudentRepository //cette classe immlémente l'interface, donc
        //elle doit repecter le contrat imposé par l'interface
    {

        //context DB
        private EleveContext _context;


        //injection de dépendence par le constructeur
        public StudentRepository()
        {
            _context = EleveContext.Instance; //on appelle le singleton
        }

        public async Task<Student> CreateEleve(Student stu)
        {
            _context.Students.Add(stu);
            await _context.SaveChangesAsync();
            return stu;
        }
        public IQueryable<Student> GetEleves()
        {
            return _context.Students;
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task<Student> DeleteEleve(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        //méthode pour modifier un eleve
        public async Task<Student> UpdateEleve(Student stu)
        {
            var existingStudent = await _context.Students.FindAsync(stu.Id);
            if (existingStudent == null)
            {
                return null;
            }

            _context.Entry(existingStudent).CurrentValues.SetValues(stu);
            await _context.SaveChangesAsync();
            return existingStudent;
        }


        //méthode pour afficher un eleve
        public async Task<Student> GetEleve(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        //méthode pour rechercher un eleve
        public async Task<Student> FindEleve(string nom)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Nom == nom);
        }
    }
}
