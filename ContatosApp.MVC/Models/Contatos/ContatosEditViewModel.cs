﻿using System.ComponentModel.DataAnnotations;

namespace ContatosApp.MVC.Models.Contatos
{
    public class ContatosEditViewModel
    {
        public Guid? Id { get; set; }

      
        public string? Nome { get; set; }

   
        public string? Email { get; set; }

    
        public string? Telefone { get; set; }
    }
}
