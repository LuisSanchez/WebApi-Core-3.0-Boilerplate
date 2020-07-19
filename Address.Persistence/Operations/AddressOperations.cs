using Address.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Address.Persistence
{
    public class AddressOperations
    {
        private readonly string connectionString;

        public AddressOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Model.Address> Find(int id)
        {
            Model.Address address = new Model.Address();

            using (var db = new AddressDBContext(connectionString))
            {
                address = await db.Addresses.Include(x => x.Country).Where(x => x.Id == id).FirstOrDefaultAsync();
            }

            return address;
        }
    }
}
