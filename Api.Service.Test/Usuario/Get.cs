using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class Get : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;


        [Fact(DisplayName = "É possível executar o Método GET.")]
        [Trait("SERVICE", "GET")]
        public async Task Execute_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);

            Assert.NotNull(result);
            //Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUsuario);

            Assert.Null(_record);

        }        
        
        [Fact(DisplayName = "É possível executar o Método GETALL.")]
        [Trait("SERVICE", "GETALL")]
        public async Task Execute_GetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _service = _serviceMock.Object;

            var _records = await _service.GetAll();

            Assert.NotNull(_records);
            Assert.True(_records.Any());

        }
    }
}
