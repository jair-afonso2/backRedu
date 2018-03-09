using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using redu.domain.Models;

namespace redu.domain.Models
{
    public class aula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAula { get; set; }

        [ForeignKey("idProfessor")]
        public professore professore { get; set; }
        public int idProfessor { get; set; }

        [ForeignKey("idTurma")]
        public turma turma { get; set; }
        public int idTurma { get; set; }
        
        [ForeignKey("idDisciplina")]
        public disciplina disciplina { get; set; }
        public int idDisciplina { get; set; }

        [ForeignKey("idDesafio")]
        public desafio desafio { get; set; }
        public int idDesafio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
    }
}
