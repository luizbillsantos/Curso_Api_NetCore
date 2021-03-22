using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos")]
        [Trait("Service", "Auto Mapper")]
        public void Teste_Mapper()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<UserEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                listaEntity.Add(item);
            }

            //Model to Entity
            var dtoToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);


            //Entity to DTO
            var userDto = Mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(userDto.Id, dtoToEntity.Id);
            Assert.Equal(userDto.Name, dtoToEntity.Name);
            Assert.Equal(userDto.Email, dtoToEntity.Email);
            Assert.Equal(userDto.CreateAt, dtoToEntity.CreateAt);

            var listDto = Mapper.Map<List<UserDto>>(listaEntity);

            Assert.True(listaEntity.Count == listDto.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(dtoToEntity);
            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(dtoToEntity);
        }
    }
}
