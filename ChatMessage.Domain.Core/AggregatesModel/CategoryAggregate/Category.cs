using ChatMesssage.Domain.Core.AggregatesModel.CategoryAggregate;
using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Domain.Core.SeedWork;

namespace ChatMesssage.Domain.Core
{
    public class Category : AggregateRoot<CategoryId>
    {
        public string CategoryName { get; private set; }
        public bool IsActive { get; private set; }
        public string Description { get; private set; }
        public CategoryThumbnail Thumbnail { get; private set; }

        private readonly List<CategoryFeature> _categoryFeatures = new List<CategoryFeature>();
        public IReadOnlyList<CategoryFeature> CategoryFeatures => _categoryFeatures;
       
        
        public static Category CreateNew(string categoryName, bool isActive, string desscription, List<Guid> features,
            string? thumbnailPath, string? thumbnailName, string? thumbnailExtension, int? thumbnailSize)
        {
            var categoryId = new CategoryId(Guid.NewGuid());
            return new Category(categoryId, categoryName, isActive, desscription, features, thumbnailPath, thumbnailName, thumbnailExtension, thumbnailSize);
        }

        private void BuildFeatures(List<Guid> featureData)
        {
            if (featureData == null) return; 

            featureData.ForEach(featureId =>
            {
                var newFeature = CategoryFeature.CreateNew(Id, new FeatureId(featureId));
                _categoryFeatures.Add(newFeature);
            });
        }

        private void BuildThumbnail(string? filePath, string? fileName, string? fileExtension, int? fileSize)
        {
            if (string.IsNullOrEmpty(filePath)) return;
            Thumbnail = new CategoryThumbnail();
            Thumbnail.FilePath = filePath;
            Thumbnail.FileName = fileName;
            Thumbnail.Extension = fileExtension;
            Thumbnail.Size = fileSize.Value;
        }

        private Category(CategoryId id, string categoryName, bool isActive, string desscription, List<Guid> features,
            string? thumbnailPath, string? thumbnailName, string? thumbnailExtension, int? thumbnailSize)
        {
            //validation....
            Id = id;
            CategoryName = categoryName;
            IsActive = isActive;
            Description = desscription;
            BuildThumbnail(thumbnailPath, thumbnailName, thumbnailExtension, thumbnailSize);
            BuildFeatures(features);
        }

        private Category()
        {
        }
    }
}
