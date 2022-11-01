using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhmadBase.Core.Dtos;
using AhmadBase.Core.interfere.IReposetory;
using AhmadBase.Core.Types;
using AhmadBase.Inferastracter;
using AhmadBase.Inferastracter.Datas.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AhmadBase.Core.Dtos;
using AhmadBase.Web.Commands;
using AhmadBase.Web.Dtos;
using AhmadBase.web.Queries;

namespace AhmadBase.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            _mediator = mediator;
        }




        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //      ////  Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}





        [HttpGet]
        public async Task<ServiceResult<MessageResultDto>>GetMessageById(string id)
        {
            var query = new GetMessageQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }



        [HttpPost]
        ///   [Authorize]
        public async Task<ActionResult> Create([FromBody] CreateDirectMessageDto input)
        {
            var command = input.Adapt<CreateDirectMessageCommand>();
            command.FirstUserId = "Ahmad";
            var result = await _mediator.Send<ServiceResult<CreateDirectsMessageResultDto>>(command);
            return await result.AsyncResult();
        }








        //[HttpPost]
        //public async Task<MessageResultDto> MakeingMessage(string id)
        //{
        //    var query = new GetMessageQuery(id);
        //    var result = await _mediator.Send(query);
        //    return result;
        //}
    }
}
