using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redu.domain.Models
{
    public class escola
    {
        /*public escola()
        {
            this.turmas = new List<turma>();
        }*/

        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEscola { get; set; }
        
        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(100)]
        public string cnpj { get; set; }
        
        [Required]
        public string endereco { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; set; }
        
    }
}
