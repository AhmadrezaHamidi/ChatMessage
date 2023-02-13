using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ChatMesssage.Application.Services.CategoryCQRS.Commands.CreateCategory;
using ChatMesssage.Application.Services.CategoryCQRS.Queries;

namespace ChatMesssage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _mediator.Send(createCategoryRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetCategoryQuery { Id = id};
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCategoryListQuery { };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
