using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiApplication.Permanence
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("name=WebApiContext") { }

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}