using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string NomeCompleto { get; set; }

        public string? Email { get; set; }

        public string CPF { get; set; }

        public string Celular { get; set; }

        public string DataNascimento { get; set; }

        public string? UrlFoto { get; set; }

        public Guid? AppUserId { get; set; }

        public IdentityUser? IdentityUser { get; set; }
    }
}