using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;
using WebApi.Common.CrossCutting.Dtos;
using System.Linq;
using System.Collections.Generic;


namespace WebApi.Geo.Services
{
    public static class CountryService
    {
        public static CountryDto ToDto(this Country entity)
        {
            var result = new CountryDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                Alpha3Code = entity.Alpha3Code
            };
            return result;
        }
    } 
}

