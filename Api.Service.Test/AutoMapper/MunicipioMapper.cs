using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {


        [Fact(DisplayName = "É Possível Mapear os Modelos de Municipio")]
        [Trait("Service", "Auto Mapper")]
        public void Teste_Mapper()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(0000000, 9999999),
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<MunicipioEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(0000000, 9999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                listaEntity.Add(item);
            }

            //Model to Entity
            var dtoToEntity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Nome, model.Nome);
            Assert.Equal(dtoToEntity.UfId, model.UfId);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);


            //Entity to DTO
            var UfDto = Mapper.Map<MunicipioDto>(dtoToEntity);
            Assert.Equal(UfDto.Id, dtoToEntity.Id);
            Assert.Equal(UfDto.Nome, dtoToEntity.Nome);
            Assert.Equal(UfDto.UfId, dtoToEntity.UfId);

            var listDto = Mapper.Map<List<MunicipioDto>>(listaEntity);

            Assert.True(listaEntity.Count == listDto.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listDto[i].UfId, listaEntity[i].UfId);
            }

            var ufModel = Mapper.Map<MunicipioDto>(dtoToEntity);
        }
    }
}
