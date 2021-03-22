﻿using Api.Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteById(Guid id);

        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIbge);

        Task<IEnumerable<MunicipioDto>> GetAll();

        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);

        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);

        Task<bool> Delete(Guid id);
    }
}
