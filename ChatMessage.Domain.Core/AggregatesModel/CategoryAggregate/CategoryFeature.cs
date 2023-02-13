using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core
{
    public class CategoryFeature:Entity<Guid>
    {
        public CategoryId CategoryId { get; private set; }
        public FeatureId FeatureId { get; private set; }

        internal static CategoryFeature CreateNew(CategoryId categoryId, FeatureId featureId)
        {
            return new CategoryFeature(categoryId, featureId);
        }

        private CategoryFeature(CategoryId categoryId, FeatureId featureId)
        {
            CategoryId = categoryId;
            FeatureId = featureId;
        }

        private CategoryFeature()
        {

        }
    }
}
