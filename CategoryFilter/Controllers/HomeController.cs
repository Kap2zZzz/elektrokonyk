using CategoryFilter.Entities;
using CategoryFilter.Models;
using CategoryFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryFilter.Controllers
{
    public class HomeController : Controller
    {
        //private EFCategoryRepository repository = new EFCategoryRepository();
        private EFDbContext context = new EFDbContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products(string Category)
        {
            Category c = context.Categories.FirstOrDefault(x => x.Name == Category);

            if (c == null)
            {
                return HttpNotFound();
            }

            FilterViewModel model = new FilterViewModel()
            {
                CategoryName = Category,

                Products = context.Products.Where(x => x.CategoryId == c.Id).ToList(),
                Properties = context.Properties.Where(x => x.CategoryId == c.Id).ToList(),
                PropertiesValue = context.PropertiesValue.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeFilter(string Category, int? PropertyId, string PropertyValue)
        {
            string PropertyChekbox = Request.Form["PropertyChekbox"];

            Category c = context.Categories.FirstOrDefault(x => x.Name == Category);

            if (c == null)
            {
                return HttpNotFound();
            }

            FilterViewModel fvm = (FilterViewModel)Session["FilterResult"];

            if (PropertyChekbox == "on")
            {
                if (fvm == null)
                {
                    fvm = new FilterViewModel()
                    {
                        CategoryName = Category,
                        Products = context.Products.Where(x => x.CategoryId == c.Id).Where(x => x.PropertiesValue.Any(z => z.PropertyId == PropertyId && z.Value == PropertyValue)).ToList(),
                        Properties = context.Properties.Where(x => x.CategoryId == c.Id).ToList(),
                        PropertiesValue = context.PropertiesValue.ToList(),
                    };
                    Session["FilterResult"] = fvm;
                }
                else
                {
                    FilterViewModel GetSelectFilterValue = new FilterViewModel()
                    {
                        CategoryName = Category,
                        Products = context.Products.Where(x => x.CategoryId == c.Id).Where(x => x.PropertiesValue.Any(z => z.PropertyId == PropertyId && z.Value == PropertyValue)).ToList(),
                        Properties = context.Properties.Where(x => x.CategoryId == c.Id).ToList(),
                        PropertiesValue = context.PropertiesValue.ToList(),
                    };
                    fvm.Products.AddRange(GetSelectFilterValue.Products);
                    fvm.Properties.AddRange(GetSelectFilterValue.Properties);
                    fvm.PropertiesValue.AddRange(GetSelectFilterValue.PropertiesValue);
                    Session["FilterResult"] = fvm;
                }
            }
            else
            {
                FilterViewModel GetSelectFilterValue = new FilterViewModel()
                {
                    CategoryName = Category,
                    Products = context.Products.Where(x => x.CategoryId == c.Id).Where(x => x.PropertiesValue.Any(z => z.PropertyId == PropertyId && z.Value == PropertyValue)).ToList(),
                    Properties = context.Properties.Where(x => x.CategoryId == c.Id).ToList(),
                    PropertiesValue = context.PropertiesValue.ToList(),
                };

                foreach (Product p in GetSelectFilterValue.Products)
                {
                    fvm.Products.RemoveAll(x=>x.Id == p.Id);
                }

                Session["FilterResult"] = fvm;

            }
         
            //FilterViewModel fvm = new FilterViewModel()
            //{
            //    CategoryName = Category,
            //    Products = context.Products.Where(x => x.CategoryId == c.Id).Where(x => x.PropertiesValue.Any(z => z.PropertyId == PropertyId && z.Value == PropertyValue)).ToList(),
            //    Properties = context.Properties.Where(x => x.CategoryId == c.Id).ToList(),
            //    PropertiesValue = context.PropertiesValue.ToList(),
            //};

            return PartialView("_PartialProducts", fvm);
        }

        private FilterViewModel FilterResult()
        {
            FilterViewModel fvm = (FilterViewModel)Session["FilterResult"];
            if (fvm == null)
            {
                fvm = new FilterViewModel();
                Session["FilterResult"] = fvm;
            }
            return fvm;
        }

    }
}
