using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }
    }
}
