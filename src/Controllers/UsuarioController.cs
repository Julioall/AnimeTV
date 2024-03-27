using AnimeTV.Models;
using AnimeTV.Models.Usuario;
using AnimeTV.Service.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTV.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuario;
        public UsuarioController(IUsuarioInterface usuario)
        {
            _usuario = usuario;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> GetUsuarios()
        {
            ServiceResponse<List<Usuario>> response = await _usuario.GetUsuarios();
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> CreateUsuario(Usuario usuarioNovo)
        {
            ServiceResponse<List<Usuario>> response = await _usuario.CreateUsuario(usuarioNovo);
            return Ok(response);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> Authenticate(Usuario usuarioNovo)
        {
            ServiceResponse<Usuario> response = await _usuario.Authenticate(usuarioNovo);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> GetUsuarioById(int id)
        {
            ServiceResponse<Usuario> response = await _usuario.GetUsuarioById(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> UpdateUsuario(Usuario usuarioEditado)
        {
            ServiceResponse<List<Usuario>> response = await _usuario.UpdateUsuario(usuarioEditado);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Usuario>>>> DeleteUsuario(int id)
        {
            ServiceResponse<List<Usuario>> response = await _usuario.DeleteUsuario(id);
            return Ok(response);
        }
    }
}
