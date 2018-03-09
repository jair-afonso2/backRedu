using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class alternativa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAlternativas { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
        public string d { get; set; }
        public string e { get; set; }

        [StringLength(1)]
        public string correta { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("idPergunta")]
        public pergunta pergunta { get; set; }
        public int idPergunta { get; set; }
        
        public ICollection<resposta> respostas { get; set; }

        public ICollection<respostas_grupo> respostas_grupos { get; set; }
    }
}
