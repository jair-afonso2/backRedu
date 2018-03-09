using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class desafioController : Controller
    {
        private IBaseRepository<desafio> _desafioRepository;

        public desafioController(IBaseRepository<desafio> desafioRepository)
        {
            _desafioRepository = desafioRepository;
        }

       [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_desafioRepository.Listar(new string[]{"perguntas"}));
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] desafio postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _desafioRepository.Inserir(postagem);
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
        public IActionResult BuscarDesafioPorId(int id)
        {
            try
            {
                desafio desafio = _desafioRepository.Listar().Where(c => c.idDesafios == id).FirstOrDefault();

                if (desafio == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(desafio);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}