using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact(DisplayName = "CRUD User")]
        [Trait("CRUD", "User")]
        public async Task User_CRUD()
        {
            await AdicionarToken();

            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            //POST

            var userDto = new UserDtoCreate
            {
                Name = _name,
                Email = _email
            };

            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, result.Name);
            Assert.Equal(_email, result.Email);

            Assert.False(result.Id == default(Guid));

            //PUT

            var updateUserDto = new UserDtoUpdate
            {
                Id = result.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            response = await client.PutAsync($"{hostApi}users/" + result.Id, new StringContent(JsonConvert.SerializeObject(updateUserDto), Encoding.UTF8, "application/json"));
            postResult = await response.Content.ReadAsStringAsync();

            var resultPUT = JsonConvert.DeserializeObject<UserDtoUpdateResult>(postResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result.Id, resultPUT.Id);
            Assert.False(resultPUT.Name == result.Name);

            //GET
            response = await client.GetAsync($"{hostApi}users/{result.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            postResult = await response.Content.ReadAsStringAsync();
            var resultGet = JsonConvert.DeserializeObject<UserDto>(postResult);
            Assert.Equal(result.Id, resultGet.Id);
            Assert.Equal(resultPUT.Name, resultGet.Name);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}users/{result.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

    }
}
