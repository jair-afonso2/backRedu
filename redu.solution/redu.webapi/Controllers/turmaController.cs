using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    
    [Route("[controller]")]
    public class turmaController : Controller
    {
        private IBaseRepository<turma> _turmaRepository;

        public turmaController(IBaseRepository<turma> turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        /*[HttpGet]
        public IEnumerable<turma> Listar()
        {
            return _turmaRepository.Listar();
        }*/

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_turmaRepository.Listar(new string[]{"escola"}));
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] turma postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _turmaRepository.Inserir(postagem);
                    return Ok(postagem);
                }

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                return BadRequest(allErrors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarTurmaPorId(int id)
        {
            try
            {
                turma turma = _turmaRepository.Listar().Where(c => c.idTurmas == id).FirstOrDefault();

                if (turma == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(turma);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}