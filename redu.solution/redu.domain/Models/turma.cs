using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class turma
    {
        /*public turma()
        {
            this.aulas = new List<aula>();
            this.alunos = new List<aluno>();
            this.turmas_aluno = new List<turmas_aluno>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTurmas { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(100)]
        public string ano { get; set;}

        [Required]
        [StringLength(100)]
        public string serie { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [Required]
        public int statusTurma { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
        [ForeignKey("idEscola")]
        public escola escola { get; set; }
        public int idEscola { get; set; }

        /*[ForeignKey("idSerie")]
        public series_turma series_turma { get; set; }
        public int idSerie { get; set; }*/

        public ICollection<turmas_aluno> turmas_alunos { get; set; }
        public ICollection<aula> aulas { get; set; }
        public ICollection<escola> escolas { get; set; }
        public ICollection<grupo> grupos { get; set; }


    }
}
