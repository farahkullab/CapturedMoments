using CapturedMoments.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapturedMoments.Models
{
    public class Category : SharedPropcs
    { 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Image { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set; } 
    }
}
