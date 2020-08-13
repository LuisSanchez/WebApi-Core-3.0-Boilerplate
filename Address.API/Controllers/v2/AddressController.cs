using Address.API.Controllers.v1;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Controllers.v2
{
    /// <summary>
    /// Main controller for address operations
    /// </summary>
    [Route("v2/[controller]")]
    public class AddressesController : BaseController
    {
        /// <summary>
        /// Gets the address. // Obtiene la dirección.
        /// </summary>
        /// <param name="keyAddress">Address key identifier. // Identificador de la dirección.</param>
        /// <returns>Address object. // Objeto dirección.</returns>
        [HttpGet]
        public ActionResult Get([FromQuery] int id) => Ok(new { Message = $"get v2 address and key is {id}" });
    }
}