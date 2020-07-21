using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Controllers.v1
{
    [ApiController]
    [GlobalExceptionFilter]
    [EnableCors]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Base ctor.
        /// </summary>
        public BaseController()
        {
            Helpers.HeadersHelper.GetLanguage(HttpContext);
        }
    }
}