using ECommerce.API.Repositories.Interfaces;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listaUsuarios = _repository.Get();

            return Ok(listaUsuarios);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBy(int id)
        {
            var usuario = _repository.Get(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _repository.Add(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("Requisição inválida.");

            _repository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);

            if (!result)
                return NotFound("Usuário não encontrado.");

            return Ok("Usuário removido com sucesso.");
        }
    }
}
