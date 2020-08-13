using Address.API;
using Address.Contract.DTOs;
using Address.Contract.Mappers;
using Address.Persistence;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Address.Business
{
    public interface IAddressBusiness
    {
        Task<AddressDTO> Retrieve(int id);
        Task<List<AddressDTO>> Retrieve();
        Task Add(AddressDTO addressDTO);
    }

    public class AddressBusiness : IAddressBusiness
    {
        private readonly ConnectionStrings dbSettings;
        private readonly AddressOperations addressOperations;

        // Using IConfiguration with connection strings
        //public AddressBusiness(IOptions<ConnectionStrings> dbOptions)
        //{
        //    this.dbSettings = dbOptions.Value;
        //    this.addressOperations = new AddressOperations(this.dbSettings.DefaultConnection);
        //}

        // Using the connection string as a singleton
        public AddressBusiness(ConnectionStrings connectionStrings)
        {
            this.dbSettings = connectionStrings;
            this.addressOperations = new AddressOperations(this.dbSettings.DefaultConnection);
        }

        public async Task<AddressDTO> Retrieve(int id)
        {
            Persistence.Model.Address address = await this.addressOperations.Find(id);

            return AddressMapper.EntityToDTO(address);
        }

        public async Task Add(AddressDTO addressDTO)
        {
            Persistence.Model.Address address = AddressMapper.DTOToEntity(addressDTO, new Persistence.Model.Address());
            await this.addressOperations.Add(address);
        }

        public async Task<List<AddressDTO>> Retrieve()
        {
            List<Persistence.Model.Address> addresses = await this.addressOperations.Find();

            return AddressMapper.EntitiesToDTOs(addresses);
        }
    }
}
