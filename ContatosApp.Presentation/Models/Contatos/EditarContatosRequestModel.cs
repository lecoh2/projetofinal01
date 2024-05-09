namespace ContatosApp.Presentation.Models.Contatos
{
    public class EditarContatosRequestModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
