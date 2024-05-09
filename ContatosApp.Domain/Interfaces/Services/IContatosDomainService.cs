using ContatosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Interfaces.Services
{
    public  interface IContatosDomainService
    {
        void CriarContatos(Contatos contatos);
        void AtualizarContatos(Contatos contatos);
        void ExcluirContatos(Contatos contatos);

        List<Contatos>? Consultar();
        Contatos? ObterPorId(Guid id);
        Contatos? ObterPorEmail(string email);
    }
}
