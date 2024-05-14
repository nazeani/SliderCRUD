using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pronia.Core.Models
{
    public class Slider:BaseEntity
    {
        public string Percent {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
       
        [StringLength(100)]
        public string? ImageUrl { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }


    }
}
