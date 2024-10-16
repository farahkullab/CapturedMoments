using CapturedMoments.Models.CommonProp;

namespace CapturedMoments.Models
{
    public class Subscription : SharedPropcs
    {
        public int SubscriptionId { get; set; }
        public int PhotographerId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
