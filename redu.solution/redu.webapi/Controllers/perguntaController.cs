using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using redu.domain.Contracts;
using redu.domain.Models;
using redu.repository.Context;

namespace redu.webapi.Controllers
{

    [Route("[controller]")]
    public class perguntaController : Controller
    {
        private IBaseRepository<pergunta> _perguntaRepository;

        private readonly IReduContext _context;

        public perguntaController(IBaseRepository<pergunta> perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        /*[HttpGet]
        public IEnumerable<desafio> Listar()
        {
            return _desafioRepository.Listar();
        }*/

        [HttpGet]
        public IActionResult GetAction()
        {

            var perguntas = _perguntaRepository.Listar(new string[]{"desafio"});

            foreach (var item in perguntas)
            {
                item.desafio.perguntas = null;
            }

            return Ok(perguntas);
            
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] pergunta postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _perguntaRepository.Inserir(postagem);
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
        public IActionResult BuscarPerguntaPorId(int id)
        {
            try
            {
                // pergunta p = _context.perguntas
                //     .Where(c => c.idPergunta == id)
                //     .Include(d => d.alternativas)
                //     .FirstOrDefault();
                    
                pergunta pergunta = _perguntaRepository
                    .Listar(new string[]{"alternativas","desafio"})
                    .FirstOrDefault();

                pergunta.desafio.perguntas = null;

                if (pergunta == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(pergunta);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}