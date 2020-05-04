using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();

         //ALUNO
         Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor);
         Task<List<Aluno>> GetAlunosAsyncByProfessorID(int professorID, bool includeProfessor);
         Task<Aluno> GetAlunoAsyncByID(int alunoID, bool includeProfessor);

        //PROFESSOR
         Task<List<Professor>> GetAllProfessoresAsync(bool includeAluno);
         Task<Professor> GetProfessorAsyncByID(int professorID, bool includeAluno);
    }
}