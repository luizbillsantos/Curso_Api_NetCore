using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CepCrudCompleto(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de CEP")]
        [Trait("CRUD", "CEPEntity")]
        public async Task E_Possivel_Realizar_CRUD_CEP()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {

                MunicipioImplementation _repositorioM = new MunicipioImplementation(context);
                MunicipioEntity _entityM = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };

                var _MunicipioCriado = await _repositorioM.InsertAsync(_entityM);

                CepImplementation _repositorio = new CepImplementation(context);
                CepEntity _entity = new CepEntity
                {
                    Cep = "13.481.001",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 2000",
                    MunicipioId = _MunicipioCriado.Id
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Cep, _registroCriado.Cep);
                Assert.Equal(_entity.Logradouro, _registroCriado.Logradouro);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Logradouro = Faker.Address.StreetName();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Cep, _registroAtualizado.Cep);
                Assert.Equal(_entity.Logradouro, _registroAtualizado.Logradouro);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);

                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Cep, _registroSelecionado.Cep);
                Assert.Equal(_entity.Logradouro, _registroSelecionado.Logradouro);

                var _todosRegistros = await _repositorio.SelectAsync();

                Assert.True(_todosRegistros.Any());

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);

                Assert.True(_removeu);
            }
        }
    }
}
