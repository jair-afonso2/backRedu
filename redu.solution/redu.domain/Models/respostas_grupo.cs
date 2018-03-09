using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class respostas_grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRespostasGrupo { get; set; }

        [StringLength(1)]
        public string opcao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("idAlternativa")]
        public alternativa alternativa { get; set; }
        public int idAlternativa { get; set; }
        
        [ForeignKey("idGrupo")]
        public grupo grupo { get; set; }
        public int idGrupo { get; set; }
    }
}