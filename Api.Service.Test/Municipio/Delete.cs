﻿using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class Delete : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;
        [Fact(DisplayName = "É possível executar método Delete.")]
        public async Task Execute_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdMunicipio);
            Assert.True(deletado);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
