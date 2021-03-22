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
    public class Updated
    {
        private UsersController _controller;


        [Fact(DisplayName = "É Possível Realizar o Update")]
        [Trait("Application", "Update")]
        public async Task Execute_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(new UserDtoUpdateResult
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email,
                CreateAt = DateTime.Now
            });

            _controller = new UsersController(serviceMock.Object);
            //_controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = nome,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate.Id, userDtoUpdate);

            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;

            Assert.True(result is OkObjectResult);
            Assert.True(_controller.ModelState.IsValid);
            Assert.Equal(userDtoUpdate.Name , resultValue.Name);
            //Assert.True(result is BadRequestResult);
        }
    }
}
