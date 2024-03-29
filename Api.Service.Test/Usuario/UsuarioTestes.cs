﻿using Api.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }

        public static string EmailUsuario { get; set; }

        public static string NomeUsuarioAlterado { get; set; }

        public static string EmailUsuarioAlterado { get; set; }

        public static Guid IdUsuario { get; set; }

        public List<UserDto> listUserDto = new List<UserDto>();

        public List<UserDtoCreate> listUserDtoCreate = new List<UserDtoCreate>();

        public UserDto userDto;

        public UserDtoCreate userDtoCreate;

        public UserDtoCreateResult userDtoCreateResult;

        public UserDtoUpdate userDtoUpdate;

        public UserDtoUpdateResult userDtoUpdateResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                listUserDto.Add(dto);
            }

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDtoCreate()
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                listUserDtoCreate.Add(dto);
            }


            userDto = new UserDto
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Name = NomeUsuario,
                Email = EmailUsuario,
                Id = IdUsuario,
                CreateAt = DateTime.Now
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {

                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                CreateAt = DateTime.Now
            };
        }
    }
}
