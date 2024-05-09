 using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Services;
using ContatosApp.Presentation.Models.Contatos;
using ContatosApp.Presentation.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContatosApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatosDomainService _contatosDomainService;

        public ContatosController(IContatosDomainService contatosDomainService)
        {
            _contatosDomainService = contatosDomainService;
        }
        [HttpPost("criar")]
        public IActionResult Criar(CriarContatosRequestModel model)
        {
            try
            {
                var contatos = new Contatos
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone
                }
                ;
                _contatosDomainService.CriarContatos(contatos);
                var response = new CriarContatosResponseModel
                {
                    Id = contatos.Id,
                    Nome = contatos.Nome,
                    Email = contatos.Email,
                    Telefone = contatos.Telefone
                };
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            try
            {
                var contatos = _contatosDomainService.Consultar();
                var response = new List<ConsultaContatoResponseModel>();
                foreach(var item in contatos)
                {
                    response.Add(new ConsultaContatoResponseModel
                    {
                        Id=item.Id,
                        Nome=item.Nome,
                        Email=item.Email,
                        Telefone=item.Telefone
                    });
                }
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }

        }
       
        [HttpPut("Editar")]
        public IActionResult EditarContatos(EditarContatosRequestModel model)
        {
            try
            {

                var contato = new Contatos
                {
                    Id = model.Id.Value,
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone
                };
                _contatosDomainService.AtualizarContatos(contato);
                return StatusCode(201, new {Mensagem = "Contato atualizado"});
            }
            catch (Exception e)
            {
                //Http 500(Internatl server erro)
                return StatusCode(500, e.Message);

            }
        }

        [HttpGet("Buscar/{id}")]
        
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                //consultar por id
                var contato = _contatosDomainService.ObterPorId(id);
                //copiar dados do produto para a model
                if (contato == null)
                    return NoContent();//http 204
                var response = new ConsultaContatoResponseModel
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                };
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var contato = _contatosDomainService.ObterPorId(id);
                _contatosDomainService.ExcluirContatos(contato);
                return StatusCode(201, new { Mensagem = "Contato excluido" });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
