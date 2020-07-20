using Address.Business;
using Address.Contract.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Address.API.Controllers.v1
{
    [Route("v1/[controller]")]
    public class AddressesController : BaseController
    {
        private readonly IAddressBusiness addressBusiness;

        public AddressesController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<AddressDTO>> Get([FromQuery]int id)
        {
            if (id == 0) return BadRequest(Language.Resource.AddressKeyNotEmpty);

            AddressDTO addressDTO = await addressBusiness.Retrieve(id);

            if (addressDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(addressDTO);
            }
        }
    }
}