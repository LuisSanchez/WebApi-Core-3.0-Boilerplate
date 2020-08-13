using Address.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Contract.Mappers
{
    /// <summary>
    /// Maps between the entity and the dto.
    /// </summary>
    public static class AddressMapper
    {
        /// <summary>
        /// Maps an entity to a dto.
        /// </summary>
        /// <param name="address">Persistence address.</param>
        /// <returns>AddressDTO.</returns>
        public static AddressDTO EntityToDTO(Persistence.Model.Address address)
        {
            if (address == null) return null;

            AddressDTO addressDTO = new AddressDTO
            {
                Id = address.Id,
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                Number = address.Number,
                Street = address.Street,
                Country = CountryMapper.EntityToDTO(address.Country)
            };

            return addressDTO;
        }

        /// <summary>
        /// Maps a dto to an entity.
        /// </summary>
        /// <param name="addressDTO">DTO address.</param>
        /// <param name="address">Persistence address.</param>
        /// <returns>Address.</returns>
        public static Persistence.Model.Address DTOToEntity(AddressDTO addressDTO, Persistence.Model.Address address)
        {
            if (addressDTO == null) return null;
            
            if (address == null) address = new Persistence.Model.Address();

            address.Id = addressDTO.Id;
            address.Latitude = addressDTO.Latitude;
            address.Longitude = addressDTO.Longitude;
            address.Number = addressDTO.Number;
            address.Street = addressDTO.Street;

            return address;
        }

        /// <summary>
        /// Maps a collection of entities to dtos.
        /// </summary>
        /// <param name="addresses">List of entity addresses.</param>
        /// <returns>List of AddressDTO.</returns>
        public static List<AddressDTO> EntitiesToDTOs(List<Persistence.Model.Address> addresses)
        {
            if (addresses == null) return null;

            List<AddressDTO> addressesDTO = new List<AddressDTO>();
            foreach (var address in addresses)
            {
                addressesDTO.Add(EntityToDTO(address));
            }
            return addressesDTO;
        }

        /// <summary>
        /// Maps a collection of dtos to entities.
        /// </summary>
        /// <param name="addressesDTO">List of DTO addresses.</param>
        /// <returns>List of addresses.</returns>
        public static List<Persistence.Model.Address> DTOsToEntities(List<AddressDTO> addressesDTO)
        {
            if (addressesDTO == null) return null;

            List<Persistence.Model.Address> addresses = new List<Persistence.Model.Address>();
            foreach (var addressDTO in addressesDTO)
            {
                addresses.Add(DTOToEntity(addressDTO, null));
            }
            return addresses;
        }
    }
}
