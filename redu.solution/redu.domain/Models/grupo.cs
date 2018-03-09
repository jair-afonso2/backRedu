using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class grupo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGrupo { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(100)]
        public string ano { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [ForeignKey("idTurmas")]
        public turma turma { get; set; }
        public int idTurmas { get; set; }

        [Required]
        public int statusGrupo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        


    }
}