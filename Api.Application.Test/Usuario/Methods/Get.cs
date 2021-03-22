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
    public class Get
    {
        private UsersController _controller;

        [Fact(DisplayName = "É Possível executar o Método Get")]
        [Trait("Service", "Post")]
        public async Task Execute_Get()
        {

            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();
            var userDtoCreate = new UserDtoCreate();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email,
                CreateAt = DateTime.Now
            });

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.True(result is OkObjectResult);
            Assert.Equal(nome, resultValue.Name);
        }
    }
}
