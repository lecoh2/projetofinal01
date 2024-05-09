using System.ComponentModel.DataAnnotations;

namespace ContatosApp.MVC.Models.Contatos
{
    public class EditViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Email do contato.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone.")]
        public string? Telefone { get; set; }
    }
}
