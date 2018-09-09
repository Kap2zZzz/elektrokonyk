using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CategoryFilter.Models
{
    public class ProductModel
    {
        public Product Product;

        public IEnumerable<Category> Categorys;

        public List<ListItem> GetCategorys()
        {
            var CategoryItems = new List<ListItem>();
            foreach (var e in Categorys)
            {
                CategoryItems.Add(new ListItem { Text = e.Name, Value = e.Id.ToString() });
            }
            return CategoryItems;
        }
    }
}