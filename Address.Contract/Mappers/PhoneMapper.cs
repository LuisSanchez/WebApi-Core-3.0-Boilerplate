using Address.Contract.DTOs;
using Address.Persistence.Model;
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
    public static class PhoneMapper
    {
        /// <summary>
        /// Maps an entity to a dto.
        /// </summary>
        /// <param name="phone">Persistence phone.</param>
        /// <returns>PhoneDTO.</returns>
        public static PhoneDTO EntityToDTO(Persistence.Model.Phone phone)
        {
            if (phone == null) return null;

            PhoneDTO phoneDTO = new PhoneDTO()
            {
                Id = phone.Id,
                Number = phone.Number
            };

            return phoneDTO;
        }

        /// <summary>
        /// Maps a dto to an entity.
        /// </summary>
        /// <param name="phoneDTO">phoneDTO.</param>
        /// <returns>Phone.</returns>
        public static Persistence.Model.Phone DTOToEntity(PhoneDTO phoneDTO)
        {
            if (phoneDTO == null) return null;

            Phone phone = new Persistence.Model.Phone()
            {
                Number = phoneDTO.Number
            };
            
            return phone;
        }

        /// <summary>
        /// Maps a collection of entities to dtos.
        /// </summary>
        /// <param name="phones">List of entity.</param>
        /// <returns>List of PhoneDTO.</returns>
        public static List<PhoneDTO> EntitiesToDTOs(List<Persistence.Model.Phone> phones)
        {
            if (phones == null) return null;

            List<PhoneDTO> phonesDTO = new List<PhoneDTO>();
            foreach (var municipality in phones)
            {
                phonesDTO.Add(EntityToDTO(municipality));
            }
            return phonesDTO;
        }
    }
}
