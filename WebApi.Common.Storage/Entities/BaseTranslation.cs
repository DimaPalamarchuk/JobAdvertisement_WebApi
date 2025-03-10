using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebApi.Common.CrossCutting.Interfaces;

namespace WebApi.Common.Storage.Entities
{
    [Index(nameof(LanguageCode), IsUnique = false)]
    public class BaseTranslation : BaseEntity, IEntityTranslation
    {
        [MaxLength(16)]
        [Required]
        public string LanguageCode { get; set; }
    }
}
