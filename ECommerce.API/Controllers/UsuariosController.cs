using ECommerce.API.Repositories.Interfaces;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioRepository _repository;

        public UsuariosController(ILogger<UsuariosController> logger, IUsuarioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Listar usuários");

            var listaUsuarios = await _repository.Get();

            return Ok(listaUsuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var usuario = await _repository.Get(id);

            return usuario == null
                ? NotFound("Usuário não encontrado.")
                : Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Usuario usuario)
        {
            await _repository.Add(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("Requisição inválida.");

            var result = await _repository.Update(usuario)!;

            return result == null
                ? NotFound("Usuário não encontrado")
                : Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);

            return !result
                ? NotFound("Usuário não encontrado.")
                : Ok("Usuário removido com sucesso.");
        }
    }
}
