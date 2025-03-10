using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Common.Storage.Entities;

namespace WebApi.Geo.Storage.Entities
{
    [Index(nameof(Name), IsUnique = false)]
    [Table("CityTranslations", Schema = "Geo")]
    public class CityTranslation : BaseTranslation
    {
        [ForeignKey("City")]
        public Guid CityId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
