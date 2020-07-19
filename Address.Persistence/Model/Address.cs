using System;
using System.Collections.Generic;

namespace Address.Persistence.Model
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public List<Phone> Phones { get; set; }

        public Country Country { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    }
}
