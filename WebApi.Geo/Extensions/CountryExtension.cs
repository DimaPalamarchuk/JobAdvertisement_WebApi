using System.Collections.Generic;
using System.Linq;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;

namespace WebApi.Geo.Extensions
{
    public static class CountryExtension
    {
        public static CountryDto ToDto(this Country entity)
        {
            var result = new CountryDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                Alpha3Code = entity.Alpha3Code
            };  
            return result;
        }
    }
}
