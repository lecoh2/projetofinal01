using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Services
{
    public class ContatosDomainService : IContatosDomainService

    {
        //atributos 
        private readonly IContatosRepository _contatosRepository;
        public ContatosDomainService(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }
        public void AtualizarContatos(Contatos contatos)
        {
            _contatosRepository.UpDate(contatos);
        }
        public void CriarContatos(Contatos contatos)
        {
            //verifica se já existe um usuário cadastrado com o email informado
            if (_contatosRepository.Get(contatos.Email) != null)
                throw new ApplicationException("O email informado ja exta cadastrado. Tente outro.");
            //gravando o usuário
            _contatosRepository.Add(contatos);
        }

        public List<Contatos>? Consultar()
        {
            return _contatosRepository.GetAll();
        }

        public void ExcluirContatos(Contatos contatos)
        {
            _contatosRepository.Delete(contatos);
        }

        public Contatos? ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Contatos? ObterPorId(Guid id)
        {
            return _contatosRepository.GetById(id);
        }

    }
}
