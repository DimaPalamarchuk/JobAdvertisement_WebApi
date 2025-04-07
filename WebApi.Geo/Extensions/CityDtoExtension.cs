using System.Drawing;
using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;

namespace WebApi.Geo.Extensions
{
public static class CityDtoExtension
    {
        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                Id = dto.Id,
                CountryId = dto.CountryId,
            };

        }
    }
}
