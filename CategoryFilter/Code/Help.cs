using CategoryFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CategoryFilter.Code
{
    public static class Help
    {
        private static EFDbContext context = new EFDbContext();
        //private static EFCategoryRepository CategoryRepository = new EFCategoryRepository();
        //private static EFPropertyRepository PropertyRepository = new EFPropertyRepository();
        public static List<ListItem> GetCategories()
        {
            var CategoryItems = new List<ListItem>();
            foreach (var e in context.Categories)
            {
                CategoryItems.Add(new ListItem { Text = e.Name, Value = e.Id.ToString() });
            }
            return CategoryItems;
        }

        public static List<ListItem> GetProperties()
        {
            var PropertyItems = new List<ListItem>();
            foreach (var e in context.Properties)
            {
                PropertyItems.Add(new ListItem { Text = e.Name, Value = e.Id.ToString() });
            }
            return PropertyItems;
        }

        public static List<ListItem> GetProperties(int? CategoryId)
        {
            var PropertyItems = new List<ListItem>();
            foreach (var e in context.Properties.Where(x=> x.CategoryId == CategoryId))
            {
                PropertyItems.Add(new ListItem { Text = e.Name, Value = e.Id.ToString() });
            }
            return PropertyItems;
        }
    }
}