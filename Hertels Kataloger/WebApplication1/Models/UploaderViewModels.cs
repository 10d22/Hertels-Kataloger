using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UploadModel
    {
        [Required]
        public string Name { get; set; }
    }
}
