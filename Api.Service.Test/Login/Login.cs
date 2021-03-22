using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class Login
    {
        private ILoginService _service;

        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método FindByLogin")]
        [Trait("Login", "Post")]
        public async Task Execute_Login()
        {

            string email = Faker.Internet.Email();

            var objetoReturn = new {
            authenticated = true,
            create = DateTime.UtcNow,
            expiration = DateTime.UtcNow.AddHours(8),
            accessToken = Guid.NewGuid(),
            userName = email,
            name = Faker.Name.FullName(),
            message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto{
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoReturn);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);

            Assert.NotNull(result);
        }
    }
}
