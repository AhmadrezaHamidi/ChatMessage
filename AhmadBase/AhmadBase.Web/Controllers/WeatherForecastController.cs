using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhmadBase.Core.interfere.IReposetory;
using AhmadBase.Inferastracter;
using AhmadBase.Inferastracter.Datas.Entities;

namespace AhmadBase.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : BaseController
    {
        private readonly IUnitOfWork<AppDbContext> unitOfWork;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IUnitOfWork<AppDbContext> unitOfWork, ILogger<WeatherForecastController> logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }




        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}





        [HttpPost]
        public async Task<IActionResult> MakeMessage()
        {
            unitOfWork.GetRepository<MessageEntity>();
            return Ok();
        }
    }
}
