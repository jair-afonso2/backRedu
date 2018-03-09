using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class alternativaController : Controller
    {
        private IBaseRepository<alternativa> _alternativaRepository;

        public alternativaController(IBaseRepository<alternativa> alternativaRepository)
        {
            _alternativaRepository = alternativaRepository;
        }

        /*[HttpGet]
        public IEnumerable<desafio> Listar()
        {
            return _desafioRepository.Listar();
        }*/

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_alternativaRepository.Listar(new string[]{"pergunta"}));
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] alternativa postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alternativaRepository.Inserir(postagem);
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
        public IActionResult BuscarAlternativaPorId(int id)
        {
            try
            {
                alternativa alternativa = _alternativaRepository.Listar().Where(c => c.idAlternativas == id).FirstOrDefault();

                if (alternativa == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(alternativa);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}