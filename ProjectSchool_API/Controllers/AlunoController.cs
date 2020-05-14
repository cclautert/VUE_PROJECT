using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public IRepository _repo { get; }
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> getAlunoByID(int AlunoId)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncByID(AlunoId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("byProfessor/{ProfessorId}")]
        public async Task<IActionResult> getProfessorByID(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByProfessorID(ProfessorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Aluno aluno)
        {
            try
            {
                _repo.Add(aluno);

                if (await _repo.SaveChangesAsync()){
                    return Created($"/api/aluno/{aluno.Id}", aluno);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> put(int AlunoId, Aluno aluno)
        {
            try
            {
                var objAluno = await _repo.GetAlunoAsyncByID(AlunoId, false);
                if (objAluno == null) return NotFound();

                _repo.Update(aluno);

                if (await _repo.SaveChangesAsync()){
                    objAluno = await _repo.GetAlunoAsyncByID(AlunoId, true);
                    return Created($"/api/aluno/{aluno.Id}", aluno);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> delete(int AlunoId)
        {
            try
            {
                var objAluno = await _repo.GetAlunoAsyncByID(AlunoId, false);
                if (objAluno == null) return NotFound();

                _repo.Delete(objAluno);

                if (await _repo.SaveChangesAsync()){
                    return Ok();
                }                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}