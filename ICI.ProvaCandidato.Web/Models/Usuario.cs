using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo deve ter no máximo 250 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo deve ter no máximo 50 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo deve ter no máximo 250 caracteres")]
        public string Email { get; set; }
    }
}
