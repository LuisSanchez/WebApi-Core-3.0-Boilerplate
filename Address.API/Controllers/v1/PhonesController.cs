using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Address.API.Controllers.v1
{
    [Route("v1/[controller]")]
    public class PhonesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get([FromQuery]int id)
        {
            //HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent("done") };
            //switch (responseMessage.StatusCode)
            //{
            //    case System.Net.HttpStatusCode.OK:
            //        return Ok(addressDTO);
            //    case System.Net.HttpStatusCode.NotFound:
            //        return NotFound();
            //    case System.Net.HttpStatusCode.BadRequest:
            //        return BadRequest(responseMessage.Content.ReadAsStringAsync().Result);
            //    default:
            //        return BadRequest();
            //}
            return Ok();
        }
    }
}