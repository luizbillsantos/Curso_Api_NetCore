using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UfEntity, UfModel>().ReverseMap();
            CreateMap<MunicipioEntity, MunicipioModel>().ReverseMap();
            CreateMap<CepEntity, CepModel>().ReverseMap();
        }
    }
}
