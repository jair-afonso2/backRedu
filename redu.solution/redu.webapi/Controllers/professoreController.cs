using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;
using redu.repository.Context;

namespace redu.webapi.Controllers
{

    [Route("[controller]")]
    public class professoreController : Controller
    {
        private IBaseRepository<professore> _professoreRepository;

        private IReduContext _context;

        public professoreController(IBaseRepository<professore> professoreRepository, IReduContext context)
        {
            _professoreRepository = professoreRepository;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<professore> Listar()
        {
            var professores = _professoreRepository.Listar(new string[]{"usuarios"});

            foreach (var professor in professores)
            {
                foreach (var usuario in professor.usuarios)
                {
                    if(usuario.flag == 2)
                    {
                        professor.usuarios.Remove(usuario);
                        break;
                    }
                }
            }
            return professores;
        }

        /*[HttpGet]
        public IActionResult GetAction()
        {
            return Ok(_professoreRepository.Listar(new string[]{"usuario"}));
        }*/

        [HttpPost]
        public IActionResult Cadastrar([FromBody] professore postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professoreRepository.Inserir(postagem);
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
        public IActionResult BuscarProfessorPorId(int id)
        {
            try
            {
                //professore professore = _professoreRepository.Listar().Where(c => c.idProfessor == id).FirstOrDefault();

                professore professore = _professoreRepository.BuscarPorId(id, new string[]{"usuarios"});

                if (professore == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    foreach (var usuario in professore.usuarios)
                    {
                        if(usuario.flag == 2)
                        {
                            professore.usuarios.Remove(usuario);
                            break;
                        }
                    }

                    return Ok(professore);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}