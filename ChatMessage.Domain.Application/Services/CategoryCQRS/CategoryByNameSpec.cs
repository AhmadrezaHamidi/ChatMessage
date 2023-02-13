using Ardalis.Specification;
using ChatMesssage.Domain.Core;
using ChatMesssage.Domain.Core.AggregatesModel.ProductAggregate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ChatMesssage.Application.Services.CategoryCQRS;

public class CategoryByNameSpec : Specification<Category>, ISingleResultSpecification
{
    public CategoryByNameSpec(string name) =>
        Query.Where(p => p.CategoryName == name);
}
