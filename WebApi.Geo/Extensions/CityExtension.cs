using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;

namespace WebApi.Geo.Extensions
{
public static class CityExtension
    {
        public static CityDto ToDto(this City entity)
        {
            var result = new CityDto
            {
                Id = entity.Id,
                Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                CountryId = entity.CountryId
            };
            return result;
        }
    }
}