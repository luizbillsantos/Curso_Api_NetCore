using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class Get : UfTestes
    {
        private IUfService _service;

        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET.")]
        [Trait("SERVICE UF", "GET")]
        public async Task Execute_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(IdUf)).ReturnsAsync(ufDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUf);

            Assert.NotNull(result);
            //Assert.True(result.Id == IdUsuario);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUf);

            Assert.Null(_record);

        }

        [Fact(DisplayName = "É possível executar o Método GETALL.")]
        [Trait("SERVICE UF", "GETALL")]
        public async Task Execute_GetAll()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);
            _service = _serviceMock.Object;

            var _records = await _service.GetAll();

            Assert.NotNull(_records);
            Assert.True(_records.Any());

        }
    }
}
