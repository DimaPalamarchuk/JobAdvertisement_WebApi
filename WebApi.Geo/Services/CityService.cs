﻿using System;
using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;
using WebApi.Geo.Storage;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Geo.Extensions;

namespace WebApi.Geo.Services
{
    public class CityService
    {
        private GeoDbContext _geoDbContext;
        public CityService(GeoDbContext geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CityDto> GetById(Guid id)
        {
            var city = await _geoDbContext
                .Set<City>()
                .Include(x=>x.Translations)
                .AsNoTracking()
                .Where(e=>e.Id!.Equals(id))
                .SingleOrDefaultAsync();
            
            return city.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await _geoDbContext
                .Set<City>()
                .Include(x=>x.Translations)
                .AsNoTracking()
                .Select(e=>e.ToDto())
                .ToListAsync();

            return cities;
        }

        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<City>()
                .Add(entity);
            await _geoDbContext.SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CityDto>
            {
              Result = newDto,
              Status = CrudOperationResultStatus.Success  
            };
        }
    }
}
