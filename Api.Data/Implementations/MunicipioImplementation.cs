﻿using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset
                .Include(m => m.Uf)
                .FirstOrDefaultAsync(a => a.CodIBGE == codIBGE);
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _dataset
                .Include(m => m.Uf)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
