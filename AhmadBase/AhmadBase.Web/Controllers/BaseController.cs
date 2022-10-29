using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AhmadBase.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult CustomeOk(object data, string message = "")
        {
            return Ok(new Result()
            {
                Message = message,
                Data = data,
                status = StatusEnum.Success
            });
        }



        public ActionResult CustomeError(object data = null, string message = "")
        {
            return BadRequest(new Result()
            {
                Message = message,
                Data = data,
                status = StatusEnum.Failed
            });
        }
    }

    public class Result
    {
        public object Data { get; set; }
        public StatusEnum  status { get; set; }
        public string Message { get; set; }
    }

    public enum StatusEnum
    {
       Success = 1 ,
       Failed = -1
    }
}
