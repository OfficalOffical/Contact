using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Contact.Entities;

namespace Contact.DataAccess
{
    public class PhoneDBContext : DbContext
    {
        public DbSet<Entities.Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Phone;Trusted_Connection=true");

        }
        
    }
}
