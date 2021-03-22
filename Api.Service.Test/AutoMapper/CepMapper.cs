using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {

        [Fact(DisplayName = "É Possível Mapear os Modelos de Cep")]
        [Trait("Service", "Auto Mapper")]
        public void Teste_Mapper()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                MunicipioId = Guid.NewGuid(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,

            };


            var listaEntity = new List<CepEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Municipio = new MunicipioEntity()
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity()
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1,3)
                        }
                    }
                };

                listaEntity.Add(item);
            }

            //Model to Entity
            var dtoToEntity = Mapper.Map<CepEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Cep, model.Cep);
            Assert.Equal(dtoToEntity.Logradouro, model.Logradouro);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);


            //Entity to DTO
            var UfDto = Mapper.Map<CepDto>(dtoToEntity);
            Assert.Equal(UfDto.Id, dtoToEntity.Id);
            Assert.Equal(UfDto.Cep, dtoToEntity.Cep);
            Assert.Equal(UfDto.Logradouro, dtoToEntity.Logradouro);

            var listDto = Mapper.Map<List<CepDto>>(listaEntity);

            Assert.True(listaEntity.Count == listDto.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listDto[i].Logradouro, listaEntity[i].Logradouro);
            }

            var ufModel = Mapper.Map<CepDto>(dtoToEntity);
        }
    }
}
