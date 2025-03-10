using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Common.CrossCutting.ValidationAttributes;

namespace WebApi.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }

        [Required]
        [LocalizedStringRequired]
        [LocalizedStringLength(255)]
        public LocalizedString Name { get; set; } = null!;

        [Required]
        [NotDefault]
        public Guid CountryId { get; set; }

    }
}
