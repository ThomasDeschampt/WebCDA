using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataRepository
{
    public interface IStudentRepository : IDisposable //pattern gestion de la mémoire
    {
        //méthode qui renvoit la liste des éléves
        IQueryable<Student> GetEleves();

        //méthode pour créer un eleve
        Task<Student> CreateEleve(Student stu);

        //méthode pour supprimer un eleve
        Task<Student> DeleteEleve(int id);

        //méthode pour modifier un eleve
        Task<Student> UpdateEleve(Student stu);

        //méthode pour afficher un eleve
        Task<Student> GetEleve(int id);

        //méthode pour rechercher un eleve
        Task<Student> FindEleve(string nom);
    }
}
