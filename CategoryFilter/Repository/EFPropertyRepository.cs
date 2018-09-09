using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryFilter.Repository
{
    public class EFPropertyRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Property> Properties { get { return context.Properties; } }
    }
}