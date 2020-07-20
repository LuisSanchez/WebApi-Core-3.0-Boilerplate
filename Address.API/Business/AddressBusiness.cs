using Address.API;
using Address.Contract.DTOs;
using Address.Contract.Mappers;
using Address.Persistence;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Address.Business
{
    public interface IAddressBusiness
    {
        Task<AddressDTO> Retrieve(int id);
    }

    public class AddressBusiness: IAddressBusiness
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
    }
}
