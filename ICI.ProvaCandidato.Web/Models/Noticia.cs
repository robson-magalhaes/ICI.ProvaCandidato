using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICI.ProvaCandidato.Web.Models
{
    public class Noticia
    {
        public int NoticiaId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo deve ter no máximo 250 caracteres")]
        public string Titulo { get; set; }

        [Column(TypeName = "TEXT")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
