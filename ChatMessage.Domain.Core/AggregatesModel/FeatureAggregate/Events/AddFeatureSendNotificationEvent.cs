using ChatMesssage.Domain.Core.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate.Events
{
    public record class AddFeatureSendNotificationEvent : DomainEvent
    {
        public FeatureId FeatureId { get; init; }

        public AddFeatureSendNotificationEvent(FeatureId featureId)
        {
            FeatureId = featureId;
            AggregateId = featureId.Value;
        }
    }
}
