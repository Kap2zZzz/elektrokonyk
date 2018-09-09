using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CategoryFilter.Repository
{
    public class EFDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyValue> PropertiesValue { get; set; }
    }
}