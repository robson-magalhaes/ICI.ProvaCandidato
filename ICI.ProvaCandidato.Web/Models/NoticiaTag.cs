using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models
{
    public class NoticiaTag
    {
        public int NoticiaTagId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int NoticiaId { get; set; }
        public virtual Noticia Noticia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}