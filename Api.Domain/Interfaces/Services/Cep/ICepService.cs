using Api.Domain.Dtos.Cep;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);

        Task<CepDto> Get(string cep);

        Task<IEnumerable<CepDto>> GetAll();

        Task<CepDtoCreateResult> Post(CepDtoCreate cep);

        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);

        Task<bool> Delete(Guid id);
    }
}
