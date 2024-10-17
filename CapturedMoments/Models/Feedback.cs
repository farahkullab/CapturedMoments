using CapturedMoments.Models.CommonProp;

namespace CapturedMoments.Models
{
    public class Feedback : SharedPropcs
    {
        public int FeedbackId { get; set; }
        public string PhotographerName { get; set; }
        public string FeedbackText { get; set; }
        public string ClientName { get; set; }
    }
}
