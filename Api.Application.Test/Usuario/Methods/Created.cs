﻿using Api.Application.Controllers;
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
    public class Created
    {
        private UsersController _controller;


        [Fact(DisplayName = "É Possível Realizar o Create")]
        [Trait("Application", "Create")]
        public async Task Execute_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult {
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

            var userDtoCreate = new UserDtoCreate
            {
                Name = nome,
                Email = email
            };

            var result = await _controller.Post(userDtoCreate);

            Assert.True(result is CreatedResult);
            //Assert.True(result is BadRequestResult);
        }

    }
}
