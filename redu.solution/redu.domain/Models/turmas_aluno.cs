using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using redu.domain.Models;

namespace redu.domain.Models
{
    public class turmas_aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTurmasAluno { get; set; }

        [ForeignKey("idTurma")]
        public turma turma { get; set; }
        public int idTurma { get; set; }
        
        [ForeignKey("idAluno")]
        public aluno aluno { get; set; }
        public int idAluno { get; set; }
        
    }
}