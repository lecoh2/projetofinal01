using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Infra.Data.Repositories
{
    public class ContatosRepository : IContatosRepository
    {
        public void Add(Contatos contatos)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(contatos);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Contatos contatos)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(contatos);
                dataContext.SaveChanges();
            }
        }

        public Contatos? Get(string email)
        {
            using (var dataContext = new DataContext())
            {
                /*return dataContext.Set<Usuario>().Where(u => u.Email.Equals(email)).FirstOrDefault();*/
                var query = @"SELECT * FROM CONTATO 
                    WHERE EMAIL = @Email";
                return dataContext.Database.GetDbConnection().Query<Contatos>(query, new
                { @Email = email }).FirstOrDefault();
            }
        }


        public List<Contatos>? GetAll()
        {
            using (var dataContext = new DataContext())
            {
                var query = @"SELECT * FROM CONTATO";
                return dataContext.Database.GetDbConnection().Query<Contatos>(query).ToList();                             }
        }

        public Contatos? GetById(Guid contatoId)
        {
            using (var dataContext = new DataContext())
            {
                var query = @"SELECT * FROM CONTATO WHERE ID = @id";
                return dataContext.Database.GetDbConnection()
                    .Query<Contatos>(query, new
                    {
                        @Id = contatoId
                    }).FirstOrDefault();
            }
        }

        public void UpDate(Contatos contatos)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(contatos);
                dataContext.SaveChanges();
            }
        }


    }
}

