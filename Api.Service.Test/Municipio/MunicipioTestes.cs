﻿using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public static string NomeMunicipio { get; set; }
        public static int CodigoIBGEMunicipio { get; set; }
        public static string NomeMunicipioAlterado { get; set; }
        public static int CodigoIBGEMunicipioAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdUf { get; set; }

        public List<MunicipioDto> listaDto = new List<MunicipioDto>();
        public MunicipioDto municipioDto;
        public MunicipioDtoCompleto municipioDtoCompleto;
        public MunicipioDtoCreate municipioDtoCreate;
        public MunicipioDtoCreateResult municipioDtoCreateResult;
        public MunicipioDtoUpdate municipioDtoUpdate;
        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTestes()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.StreetName();
            CodigoIBGEMunicipio = Faker.RandomNumber.Next(1, 10000);
            NomeMunicipioAlterado = Faker.Address.StreetName();
            CodigoIBGEMunicipioAlterado = Faker.RandomNumber.Next(1, 10000);
            IdUf = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    CodeIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodeIBGE = CodigoIBGEMunicipio,
                UfId = IdUf
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodeIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3)
                }
            };

            municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = NomeMunicipio,
                CodeIBGE = CodigoIBGEMunicipio,
                UfId = IdUf
            };

            municipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodeIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                CreateAt = DateTime.UtcNow
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodeIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodeIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
