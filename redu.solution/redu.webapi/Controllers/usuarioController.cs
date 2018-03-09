using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using redu.domain.Contracts;
using redu.domain.Models;

namespace redu.webapi.Controllers
{
    [Route("[controller]")]
    public class usuarioController : Controller
    {
        private IBaseRepository<usuario> _usuarioRepository;

        public usuarioController(IBaseRepository<usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IEnumerable<usuario> Listar()
        {
            return _usuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] usuario postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Inserir(postagem);
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
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                usuario usuario = _usuarioRepository.Listar().Where(c => c.idUsuarios == id).FirstOrDefault();

                if (usuario == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}