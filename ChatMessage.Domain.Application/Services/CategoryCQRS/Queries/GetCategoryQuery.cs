using ChatMesssage.Application.Common.FileStorage;
using ChatMesssage.Domain.Core;
using MediatR;

namespace ChatMesssage.Application.Services.CategoryCQRS.Queries
{
    public class GetCategoryQuery : IRequest<GetCategoryQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryQueryResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public List<Guid> Features { get; set; }
    }

    public class CategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryQueryResponse>
    {
        private readonly Domain.Core.SeedWork.Repository.IRepository<Category> _categoryRepository;
        private readonly IFileStorageService _fileStorageService;

        public CategoryQueryHandler(Domain.Core.SeedWork.Repository.IRepository<Category> categoryRepository,
            IFileStorageService fileStorageService)
        {
            _categoryRepository = categoryRepository;
            _fileStorageService = fileStorageService;
        }
        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryId = new CategoryId(request.Id);
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null) return null;

            var model = new GetCategoryQueryResponse();
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;
            model.Id = category.Id.Value;
            model.Thumbnail = _fileStorageService.GetFilePath(category.Thumbnail.FilePath);

            return model;
        }
    }
}
