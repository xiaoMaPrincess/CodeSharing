using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreMVCDemo.Models
{
    public class MvcDbContext:DbContext
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options):base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
    }
}
