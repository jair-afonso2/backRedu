using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using redu.domain.Models;

namespace redu.domain.Models
{
    public class usuario
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuarios { get; set; }
        
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        
        [Required]
        [StringLength(100)]
        public string senha { get; set; }
        
        [Required]
        [StringLength(100)]        
        public string nome { get; set; }

        [Required]
        [StringLength(100)]        
        public string sobrenome { get; set; }
        
        [Required]
        public int flag { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("idAluno_Professor")]
        public aluno aluno { get; set; }

        [ForeignKey("idAluno_Professor")]
        public professore professore { get; set; }

        public int idAluno_Professor { get; set; }

    }
}
