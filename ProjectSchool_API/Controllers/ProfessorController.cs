using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> getProfessorByID(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessorAsyncByID(ProfessorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("byAluno/{AlunoId}")]
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

        [HttpPost]
        public async Task<IActionResult> post(Professor professor)
        {
            try
            {
                _repo.Add(professor);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Professor/{professor.Id}", professor);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> put(int ProfessorId, Professor professor)
        {
            try
            {
                var objProfessor = await _repo.GetProfessorAsyncByID(ProfessorId, false);
                if (objProfessor == null) return NotFound();

                _repo.Update(professor);

                if (await _repo.SaveChangesAsync()){
                    objProfessor = await _repo.GetProfessorAsyncByID(ProfessorId, true);
                    return Created($"/api/professor/{objProfessor.Id}", objProfessor);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> delete(int ProfessorId)
        {
            try
            {
                var objProfessor = await _repo.GetProfessorAsyncByID(ProfessorId, false);
                if (objProfessor == null) return NotFound();

                _repo.Delete(objProfessor);

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