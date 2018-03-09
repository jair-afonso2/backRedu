using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class disciplina
    {
        /*public disciplina()
        {
            this.aulas = new List<aula>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDisciplina { get; set; }
        
        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        public ICollection<aula> aulas { get; set; }
    }
}
