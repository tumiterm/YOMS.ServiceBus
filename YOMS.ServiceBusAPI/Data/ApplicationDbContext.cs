using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YOMS.ServiceBusAPI.Models;

namespace YOMS.ServiceBusAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Profilling> Customers { get; set; }

    }
}