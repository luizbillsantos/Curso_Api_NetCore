using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTesteService
    {

        [Fact(DisplayName = "É Possível Mapear os Modelos de UF")]
        [Trait("Service", "Auto Mapper")]
        public void Teste_Mapper()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1,3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<UfEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                listaEntity.Add(item);
            }

            //Model to Entity
            var dtoToEntity = Mapper.Map<UfEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Nome, model.Nome);
            Assert.Equal(dtoToEntity.Sigla, model.Sigla);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);


            //Entity to DTO
            var UfDto = Mapper.Map<UfDto>(dtoToEntity);
            Assert.Equal(UfDto.Id, dtoToEntity.Id);
            Assert.Equal(UfDto.Nome, dtoToEntity.Nome);
            Assert.Equal(UfDto.Sigla, dtoToEntity.Sigla);

            var listDto = Mapper.Map<List<UfDto>>(listaEntity);

            Assert.True(listaEntity.Count == listDto.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listDto[i].Sigla, listaEntity[i].Sigla);
            }

            var ufModel = Mapper.Map<UfDto>(dtoToEntity);
        }
    }
}
