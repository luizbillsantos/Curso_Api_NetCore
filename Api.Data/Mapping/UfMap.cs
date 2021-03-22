using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {

            builder.ToTable("Uf");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Sigla)
                .IsUnique();
        }
    }
}
