using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class resposta
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRespostas { get; set; }
        
        [StringLength(1)]
        public string opcao { get; set; }

        [Required]
        public int pontuacao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("idAlternativa")]
        public alternativa alternativa { get; set; }
        public int idAlternativa { get; set; }
        
        [ForeignKey("idAluno")]
        public aluno aluno { get; set; }
        public int idAluno { get; set; }
        
    }
}
