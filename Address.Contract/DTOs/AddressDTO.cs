using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Contract.DTOs
{
    /// <summary>
    /// AddressDTO object.
    /// </summary>
    public class AddressDTO
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public List<PhoneDTO> Phones { get; set; }

        public CountryDTO Country { get; set; }
    }
}
