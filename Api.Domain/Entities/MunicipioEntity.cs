using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        [Required]
        [ForeignKey("Uf")]
        public Guid UfId { get; set; }

        public virtual UfEntity Uf { get; set; }

        public virtual List<CepEntity> Ceps { get; set; }
    }
}
