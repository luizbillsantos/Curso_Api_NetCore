using Api.Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int CodeIBGE { get; set; }

        public Guid UfId { get; set; }

        public UfDto Uf { get; set; }
    }
}
