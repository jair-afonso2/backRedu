using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using redu.domain.Models;

namespace redu.domain.Models
{
    public class professore
    {
        /*public professore()
        {
            this.aulas = new List<aula>();
            this.usuarios = new List<usuario>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProfessor { get; set; }
        
        [Required]
        [StringLength(100)]
        public string cpf { get; set; }
        
        [Required]
        [StringLength(100)]
        public string cidade { get; set; }
        
        [Required]
        [StringLength(100)]
        public string estado { get; set; }
        
        [Required]
        [StringLength(45)]
        public string telefone { get; set; }
        
        [Required]
        [StringLength(100)]  
        public string nascimento { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        public ICollection<aula> aulas { get; set; }
        public ICollection<usuario> usuarios { get; set; }
    }
}
