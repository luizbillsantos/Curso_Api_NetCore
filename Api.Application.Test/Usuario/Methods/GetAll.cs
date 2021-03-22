using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.Methods
{
    public class GetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possível executar o Método GetAll")]
        [Trait("Service", "Post")]
        public async Task Execute_GetAll()
        {

            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var userDtoCreate = new UserDtoCreate();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                    new UserDto
                    {

                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.Now

                    }, 
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.Now
                    }
                });

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();
            var resultValue = ((OkObjectResult)result).Value as List<UserDto>;
            Assert.True(result is OkObjectResult);
            Assert.True(resultValue.Count == 2);
        }
    }
}
