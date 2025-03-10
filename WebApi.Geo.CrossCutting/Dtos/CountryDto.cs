using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.CrossCutting.Dtos;
using WebApi.Common.CrossCutting.ValidationAttributes;

namespace WebApi.Geo.CrossCutting.Dtos
{
    public class CountryDto
    {
        public Guid Id { get; set; }

        [LocalizedStringRequiredAttribute]
        [LocalizedStringLengthAttribute(32)]
        public LocalizedString Name { get; set; }

        [MaxLength(3)]
        [MinLength(2)]
        [Required]
        public string Alpha3Code { get; set; }
    }
}
