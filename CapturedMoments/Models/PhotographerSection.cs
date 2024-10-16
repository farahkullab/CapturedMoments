using CapturedMoments.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapturedMoments.Models
{
    public class PhotographerSection :SharedPropcs
    {
        public int photographersectionId { get; set; }
        public String photographerName { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string btnText { get; set; }

    }
}
