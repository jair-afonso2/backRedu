using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class escolaController : Controller
    {
        private IBaseRepository<escola> _escolaRepository;

        public escolaController(IBaseRepository<escola> escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        [HttpGet]
        public IEnumerable<escola> Listar()
        {
            return _escolaRepository.Listar();
        }

        /*[HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_escolaRepository.Listar(new string[]{"escola"}));
        }*/

        [HttpPost]
        public IActionResult Cadastrar([FromBody] escola postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _escolaRepository.Inserir(postagem);
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
        public IActionResult BuscarEscolaPorId(int id)
        {
            try
            {
                escola escola = _escolaRepository.Listar().Where(c => c.idEscola == id).FirstOrDefault();

                if (escola == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(escola);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}

