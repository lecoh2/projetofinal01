using ContatosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Interfaces.Repositories
{
    public interface IContatosRepository
    {
        void Add(Contatos contatos);
        void UpDate(Contatos contatos);
        void Delete(Contatos contatos);
        Contatos? Get(string email);
        Contatos? GetById(Guid id);
        List<Contatos>? GetAll();


    }
}
