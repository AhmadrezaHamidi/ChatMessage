using ChatMesssage.Application.Common.FileStorage;
using ChatMesssage.Domain.Core;
using MediatR;

namespace ChatMesssage.Application.Services.CategoryCQRS.Queries
{
    public class GetCategoryListQuery : IRequest<List<GetCategoryListQueryResponse>>
    {
       
    }

    public class GetCategoryListQueryResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Thumbnail { get; set; }
        public int FeatureCount { get; set; }
    }

    public class CategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<GetCategoryListQueryResponse>>
    {
        private readonly Domain.Core.SeedWork.Repository.IRepository<Category> _categoryRepository;
        private readonly IFileStorageService _fileStorageService;

        public CategoryListQueryHandler(Domain.Core.SeedWork.Repository.IRepository<Category> categoryRepository,
            IFileStorageService fileStorageService)
        {
            _categoryRepository = categoryRepository;
            _fileStorageService = fileStorageService;
        }
        public async Task<List<GetCategoryListQueryResponse>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ListAsync();
            if (categories == null) return null;

            var result = new List<GetCategoryListQueryResponse>();
            foreach (var category in categories)
            {
                var categoryListQueryResponse = new GetCategoryListQueryResponse()
                {
                    CategoryName = category.CategoryName,
                    Id = category.Id.Value,
                    Thumbnail = _fileStorageService.GetFilePath(category.Thumbnail.FilePath),
                    FeatureCount = category.CategoryFeatures.Count,
                };
                result.Add(categoryListQueryResponse);
            }

            return result;
        }
    }
}
