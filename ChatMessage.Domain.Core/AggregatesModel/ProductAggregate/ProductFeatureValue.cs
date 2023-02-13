using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core.AggregatesModel.ProductAggregate
{
    public class ProductFeatureValue : Entity<Guid>
    {
        public ProductId ProductId { get; private set; }
        public FeatureId FeatureId { get; private set; }
        public string Value { get; private set; }

        internal static ProductFeatureValue CreateNew(ProductId productId, FeatureId featureId, string value)
        {
            return new ProductFeatureValue(productId, featureId, value);
        }

        private ProductFeatureValue(ProductId productId, FeatureId featureId, string value)
        {
            ProductId = productId;
            FeatureId = featureId;
            Value = value;
        }

        private ProductFeatureValue()
        {

        }
    }
}
