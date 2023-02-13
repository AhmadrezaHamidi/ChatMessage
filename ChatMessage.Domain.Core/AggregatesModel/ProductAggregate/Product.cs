using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Domain.Core.SeedWork;
using DevTubeCommerce.Domain.Core.ChatMesssages.Products.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Domain.Core.AggregatesModel.ProductAggregate
{
    public class Product : AggregateRoot<ProductId>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public double Price { get; private set; }
        public CategoryId CategoryId { get; private set; }

        private readonly List<ProductFeatureValue> _productFeatureValues = new List<ProductFeatureValue>();
        public IReadOnlyList<ProductFeatureValue> ProductFeatureValues => _productFeatureValues;


        private readonly List<ProductAttachment> _productAttachments = new List<ProductAttachment>();
        public IReadOnlyList<ProductAttachment> ProductAttachments => _productAttachments;

        internal static Product CreateNew(CategoryId categoryI, string title, string description, string code, double price, List<ProductFeatureValue> productFeatures)
        {
            return new Product(categoryI, title, description, code, price, productFeatures);
        }

        private void BuildFeatures(List<ProductFeatureValue> featureData)
        {
            featureData.ForEach(feature =>
            {
                var newFeature = ProductFeatureValue.CreateNew(Id, feature.FeatureId, feature.Value);
                _productFeatureValues.Add(newFeature);
            });
        }

        private Product(CategoryId categoryId, string title, string description, string code, double price, List<ProductFeatureValue> productFeatures)
        {
            if (price < 0) throw new BusinessRuleException("invalid price value");
            CategoryId = categoryId;
            Title = title;
            Code = code;
            Description = description;
            Price = price;
            BuildFeatures(productFeatures);
            AddDomainEvent(new AddProductSendNotificationEvent(Id));
        }

        private Product(){}
    }
}
