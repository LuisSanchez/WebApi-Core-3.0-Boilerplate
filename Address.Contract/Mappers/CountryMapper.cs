using Address.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address.Contract.Mappers
{
    /// <summary>
    /// Maps countries between the entity and the dto.
    /// </summary>
    public static class CountryMapper
    {
        /// <summary>
        /// Maps an entity to a dto.
        /// </summary>
        /// <param name="country">Persistence country.</param>
        /// <returns>CountryDTO.</returns>
        public static CountryDTO EntityToDTO(Persistence.Model.Country country)
        {
            if (country == null) return null;

            CountryDTO countryDTO = new CountryDTO()
            {
                Name = country.Name,
                CountryCode = country.CountryCode
            };

            return countryDTO;
        }

        /// <summary>
        /// Maps a collection of entities to dtos.
        /// </summary>
        /// <param name="countries">List of entity countries.</param>
        /// <returns>List of CountryDTO.</returns>
        public static List<CountryDTO> EntitiesToDTOs(List<Persistence.Model.Country> countries)
        {
            if (countries == null) return null;

            List<CountryDTO> countriesDTO = new List<CountryDTO>();
            foreach (var country in countries)
            {
                countriesDTO.Add(EntityToDTO(country));
            }
            return countriesDTO;
        }
    }
}
