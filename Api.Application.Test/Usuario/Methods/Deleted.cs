using Api.Application.Controllers;
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
    public class Deleted
    {

        private UsersController _controller;

        [Fact(DisplayName = "É Possível executar o Método Delete")]
        [Trait("Service", "Post")]
        public async Task Execute_Delete()
        {

            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.Delete(Guid.NewGuid());

            Assert.True(result is OkObjectResult);
        }
    }
}
