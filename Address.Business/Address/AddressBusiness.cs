using Address.Contract.DTOs;
using Address.Contract.Mappers;
using System;
using System.Threading.Tasks;

namespace Address.Business
{
    public class AddressBusiness
    {
        public static async Task<AddressDTO> Retrieve(int id)
        {
            //Persistence.Model.Address address = await Persistence.AddressOperations.Find(id);

            //return AddressMapper.EntityToDTO(address);
            throw new NotImplementedException();
        }
    }
}
