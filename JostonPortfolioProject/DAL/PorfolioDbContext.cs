using JostonPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JostonPortfolioProject.DAL
{
    public class PorfolioDbContext :DbContext
    {
        public PorfolioDbContext():base("Portfolio") { }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}