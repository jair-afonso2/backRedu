using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class aluno
    {
        /*public aluno()
        {
            this.respostas = new List<resposta>();
            this.usuarios = new List<usuario>();
            this.turmas = new List<turma>();
            this.turmas_aluno = new List<turmas_aluno>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAluno { get; set; }
        
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
        [DataType(DataType.Date)]
        public System.DateTime nascimento { get; set; }
        
        [Required]
        [StringLength(100)]
        public string nomeResponsavel { get; set; }

        [ForeignKey("idEscola")]
        public escola escola { get; set; }
        public int idEscola { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }


        public ICollection<turmas_aluno> turmas_alunos { get; set; }
        public ICollection<resposta> respostas { get; set; }
        public ICollection<usuario> usuarios { get; set; }

    }
}
