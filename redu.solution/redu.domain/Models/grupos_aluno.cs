using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class grupos_aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGruposAluno { get; set; }

        [ForeignKey("idGrupo")]
        public grupo grupo { get; set; }
        public int idGrupo { get; set; }
        
        [ForeignKey("idAluno")]
        public aluno aluno { get; set; }
        public int idAluno { get; set; }

    }
}