using System;
using System.Collections.Generic;
using System.Text;

namespace Address.Persistence.Model
{
    public class Phone
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    }
}
