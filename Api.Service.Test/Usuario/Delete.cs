using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class Delete : UsuarioTestes
    {

        private IUserService _service;

        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Delete")]
        [Trait("Service", "Delete")]
        public async Task Execute_Delete()
        {

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUsuario);

            Assert.True(result);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var resultDel = await _service.Delete(IdUsuario);

            Assert.False(resultDel);
        }
    }
}
