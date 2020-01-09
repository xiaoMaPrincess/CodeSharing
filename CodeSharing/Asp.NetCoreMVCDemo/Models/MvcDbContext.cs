using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Asp.NetCoreMVCDemo.Models
{
    #region DbContext

    //public class MvcDbContext:DbContext
    //{
    //    public MvcDbContext(DbContextOptions<MvcDbContext> options):base(options)
    //    {

    //    }
    //    public DbSet<Person> Person { get; set; }
    //    public DbSet<Hobby> Hobby { get; set; }
    //}
    #endregion

    public class MvcDbContext : IdentityDbContext<IdentityUser>
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
    }
}
