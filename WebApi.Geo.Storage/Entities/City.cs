using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Geo.Storage.Entities
{
    [Table("Cities", Schema = "Geo")]
    public class City : BaseEntity
    {
        [Required]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<CityTranslation> Translations { get; set; }
    }
}
