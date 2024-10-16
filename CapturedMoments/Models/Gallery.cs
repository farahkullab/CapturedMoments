using CapturedMoments.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapturedMoments.Models
{
    public class Gallery : SharedPropcs
    {
        public int Id { get; set; }
        [ForeignKey("Photographer")]
        public int PhotographerId { get; set; }
        public Photographer? Photographer { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public  IFormFile ImageFile { get; set; } 
        public bool IsFeatured { get; set; }

    }
}
