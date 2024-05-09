namespace ContatosApp.MVC.Models.Usuarios
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public string? Telefone { get; set; }
    }
}
