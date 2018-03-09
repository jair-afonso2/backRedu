using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class series_turma
    {
        /*public series_turma()
        {
            this.turmas = new List<turma>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSerie { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ano { get; set; }
        
        [Required]
        [StringLength(100)]
        public string serie { get; set; }
        
        [Required]
        [StringLength(100)]
        public string descricao { get; set; }
        
        public ICollection<turma> turmas { get; set; }
        
    }
}
