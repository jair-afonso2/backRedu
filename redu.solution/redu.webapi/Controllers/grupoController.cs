using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class grupoController : Controller
    {
        private IBaseRepository<grupo> _grupoRepository;

        public grupoController(IBaseRepository<grupo> grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        /*[HttpGet]
        public IEnumerable<professore> Listar()
        {
            return _professoreRepository.Listar();
        }*/

        [HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_grupoRepository.Listar(new string[]{"turma"}));
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] grupo postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _grupoRepository.Inserir(postagem);
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
        public IActionResult BuscarGrupoPorId(int id)
        {
            try
            {
                grupo grupo = _grupoRepository.Listar().Where(c => c.idGrupo == id).FirstOrDefault();

                if (grupo == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(grupo);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}