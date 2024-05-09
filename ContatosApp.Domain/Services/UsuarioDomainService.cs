using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Helpers;
using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        // atributo

        private readonly IUsuarioRepository _usuarioRepository;
        //método construtor para injeção de dependência
        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario? AutenticarUsuario(string email, string senha)
        {

            //consultar 1 usuario no banco de daodos atraves do email e da senha

            var usuario = _usuarioRepository.Get(email, Sha256CryptoHelper.CalculateSHA256(senha));
            //verifica se o usuairo não foi encontrado

            if (usuario == null)
                throw new ApplicationException
                    ("Acesso negado. Usuário não encontrado.");

            //retornanbdo o usuairo
            return usuario;
        }

        public void CriarUsuario(Usuario usuario)
        {
            //verifica se já existe um usuário cadastrado com o email informado
            if (_usuarioRepository.Get(usuario.Email) != null)
                throw new ApplicationException
                    ("O email informado já está cadastrado. Tente outro.");
            //criptografar a senha do usuário
            usuario.Senha = Sha256CryptoHelper.CalculateSHA256(usuario.Senha);

            //gravando o usuário no banco de dados
            _usuarioRepository.Add(usuario);
        }
    }
}
