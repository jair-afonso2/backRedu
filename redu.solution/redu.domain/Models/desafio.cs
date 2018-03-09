using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class desafio
    {
        /*public desafio()
        {
            this.aulas = new List<aula>();
            this.perguntas = new List<pergunta>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDesafios { get; set; }
        
        [Required]
        [StringLength(100)]
        public string nome { get; set; }
        
        
        public string descricao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        public ICollection<aula> aulas { get; set; }
        public ICollection<pergunta> perguntas { get; set; }
    }
}
