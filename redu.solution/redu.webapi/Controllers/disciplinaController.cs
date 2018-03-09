using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class disciplinaController : Controller
    {
        private IBaseRepository<disciplina> _disciplinaRepository;

        public disciplinaController(IBaseRepository<disciplina> disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public IEnumerable<disciplina> Listar()
        {
            return _disciplinaRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] disciplina postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _disciplinaRepository.Inserir(postagem);
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
    }
} 