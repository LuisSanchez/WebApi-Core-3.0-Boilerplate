using Address.API.Controllers.v1;
using Address.Business;
using Address.Contract.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.API.Controllers.v3
{
    /// <summary>
    /// Main controller for address operations
    /// </summary>
    [Route("v3/[controller]")]
    public class AddressesController : BaseController
    {
        private readonly IAddressBusiness addressBusiness;

        public AddressesController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> Get()
        {
            List<AddressDTO> addressDTO = await addressBusiness.Retrieve();

            return addressDTO.Any() ? Ok(addressDTO) : Ok(new { });

        }
    }
}