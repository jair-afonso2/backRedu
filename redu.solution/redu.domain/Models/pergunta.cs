using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class pergunta
    {
        /*public pergunta()
        {
            this.alternativas = new List<alternativa>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPergunta { get; set; }
        
        [Required]
        public string titulo { get; set; }

        [ForeignKey("idDesafio")]
        public desafio desafio { get; set; }        
        public int idDesafio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        public ICollection<alternativa> alternativas { get; set; }

    }
}
