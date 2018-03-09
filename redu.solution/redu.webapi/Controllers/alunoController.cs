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
    public class alunoController : Controller
    {
        private IBaseRepository<aluno> _alunoRepository;

        private IReduContext _context;

        public alunoController(IBaseRepository<aluno> alunoRepository, IReduContext context)
        {
            _alunoRepository = alunoRepository;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<aluno> Listar()
        {
            var alunos = _alunoRepository.Listar(new string[]{"usuarios", "turmas_alunos"});

            foreach (var aluno in alunos)
            {
                foreach (var usuario in aluno.usuarios)
                {
                    if(usuario.flag == 1)
                    {
                        aluno.usuarios.Remove(usuario);
                        break;
                    }
                }
            }
            return alunos;
        }
        
        

        [HttpPost]
        public IActionResult Cadastrar([FromBody] aluno postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoRepository.Inserir(postagem);
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
        public IActionResult BuscarAlunoPorId(int id)
        {
            try
            {
                aluno aluno = _alunoRepository.BuscarPorId(id, new string[]{"usuarios"});

                if (aluno == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    foreach (var usuario in aluno.usuarios)
                    {
                        if(usuario.flag == 1)
                        {
                            aluno.usuarios.Remove(usuario);
                            break;
                        }
                    }
            
                    return Ok(aluno);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut ("{id}")]
        public IActionResult Autalizar(int id)

        {
            var aluno = _alunoRepository.BuscarPorId(id);
            return Ok(_alunoRepository.Atualizar(aluno));
        }
    }
}