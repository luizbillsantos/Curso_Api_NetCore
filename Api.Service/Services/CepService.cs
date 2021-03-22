using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;

        private readonly IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<IEnumerable<CepDto>> GetAll()
        {
            var entity = await _repository.SelectAsync();
            return _mapper.Map<List<CepDto>>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var Model = _mapper.Map<CepDto>(cep);
            var entity = _mapper.Map<CepEntity>(Model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var Model = _mapper.Map<CepDto>(cep);
            var entity = _mapper.Map<CepEntity>(Model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CepDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
