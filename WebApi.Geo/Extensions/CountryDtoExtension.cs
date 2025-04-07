using WebApi.Geo.CrossCutting.Dtos;
using WebApi.Geo.Storage.Entities;

namespace WebApi.Geo.Extensions
{
    public static class CountryDtoExtension
    {
        public static Country ToEntity(this CountryDto dto)
        {
            return new Country
            {
                Id = dto.Id,
                Alpha3Code = dto.Alpha3Code
            };
        }
    }
}
