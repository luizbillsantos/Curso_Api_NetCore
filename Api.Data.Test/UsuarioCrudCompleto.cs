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
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);

                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);

                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_entity.Name, _registroSelecionado.Name);
                Assert.Equal(_entity.Email, _registroSelecionado.Email);


                var _todosRegistros = await _repositorio.SelectAsync();

                Assert.True(_todosRegistros.Any());

                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);

                Assert.True(_removeu);

                var _usuarioPadrao = await _repositorio.FindByLogin("luizbillsantos@gmail.com");

                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("luizbillsantos@gmail.com", _usuarioPadrao.Email);
            }
        }
    }
}
