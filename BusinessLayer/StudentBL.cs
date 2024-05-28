using DataRepository;
using IBusinessLayer;
using IDataRepository;
using Models;

namespace BusinessLayer
{
    public class StudentBL : IStudentBL
    {

        //on doit passer par l'interface de la couche DataAccessLayer
        IStudentRepository _dataFactory;

        //Constructeur visible - celui qui sera appelé
        //Injection de dépendence par le constructeur
        public StudentBL() : this(new StudentRepository())
        {
        }


        //constructeur privé
        private StudentBL(IStudentRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }


        public Task<Student> CreateEleve(Student stu)
        {
            return _dataFactory.CreateEleve(stu);
             
        }

        public void Dispose()
        {
            if (_dataFactory != null)
            {
                _dataFactory.Dispose();
            }
        }

        public IQueryable<Student> GetEleves()
        {
            return _dataFactory.GetEleves();
        }

        public  Task<Student> DeleteEleve(int id)
        {
            return _dataFactory.DeleteEleve(id);
        }

        public Task<Student> UpdateEleve(Student stu)
        {
            return _dataFactory.UpdateEleve(stu);
        }

        public Task<Student> GetEleve(int id)
        {
            return _dataFactory.GetEleve(id);
        }

        public Task<Student> FindEleve(string nom)
        {
            return _dataFactory.FindEleve(nom);
        }
    }
}
