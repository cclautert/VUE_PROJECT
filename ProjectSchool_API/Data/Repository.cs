using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }        

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //ALUNOS
        public async Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor){
                query = query.Include(c => c.Professor);
            }

            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Aluno>> GetAlunosAsyncByProfessorID(int professorID, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor){
                query = query.Include(c => c.Professor);
            }

            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(p => p.ProfessorID == professorID);

            return await query.ToListAsync();
        }

        public async Task<Aluno> GetAlunoAsyncByID(int alunoID, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor){
                query = query.Include(c => c.Professor);
            }

            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(p => p.Id == alunoID);

            return await query.FirstOrDefaultAsync();
        }

        //PROFESSORES
        public async Task<List<Professor>> GetAllProfessoresAsync(bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            /*if (includeAluno){
                query = query.Include(c => c.Alunos);
            }*/

            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id);

            return await query.ToListAsync();
        }

        public async Task<Professor> GetProfessorAsyncByID(int professorID, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno){
                query = query.Include(c => c.Alunos);
            }

            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(p => p.Id == professorID);

            return await query.FirstOrDefaultAsync();
        }
    }
}