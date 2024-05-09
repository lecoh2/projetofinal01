using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Services;
using ContatosApp.Presentation.Models.Usuarios;
using ContatosApp.Presentation.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        public UsuariosControllers(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }
        [HttpPost("criar")]
        public IActionResult Criar(CriarUsuarioRequestModel model)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha
                };
                _usuarioDomainService.CriarUsuario(usuario);
                var respose = new CriarUsuarioResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraCadastro = DateTime.Now
                };
                return StatusCode(201, respose);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("autenticar")]
        [HttpPost]
        public IActionResult Autenticar(AutenticarUsuarioRequestModel model)
        {
            try
            {
                var usuario = _usuarioDomainService.AutenticarUsuario(model.Email, model.Senha);
                var response = new AutenticarUsuarioResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = TokenSecurity.GenerateToken(usuario.Id),
                    DataHoraAcesso = DateTime.Now
                };
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }


        }
    }
}
