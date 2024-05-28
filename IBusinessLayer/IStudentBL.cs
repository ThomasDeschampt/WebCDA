using Models;

namespace IBusinessLayer
{
    public interface IStudentBL : IDisposable
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
        Task<Student> FindEleve(string name);
    }
}
