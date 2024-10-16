using CapturedMoments.Models.CommonProp;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapturedMoments.Models
{
    public class Photographer : SharedPropcs
    {
        public int PhotographerId { get; set; }
        public string PhotograperName { get; set; }
        public string  Bio  { get; set; }
        public string? Image { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set; }  
        public bool SubsicriptionStatus { get; set; }
        public string SocialMediaURL { get; set; }
        public int SessionId { get; set; }

    }
}
