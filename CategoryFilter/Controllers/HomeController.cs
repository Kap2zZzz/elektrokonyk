﻿using CategoryFilter.Entities;
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
            //CategoryModel model = new CategoryModel
            //{
            //    Categorys = repository.Categories
            //};
            //var model = new repository.Categorys;
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
                Products = context.Products.Where(x=>x.CategoryId == c.Id),
                Properties = context.Properties.Where(x=> x.CategoryId == c.Id).ToList(),
                PropertiesValue = context.PropertiesValue.ToList(),
            };
            //var xxx = context.PropertiesValue.GroupBy(x => x.Value, x => x.PropertyId).ToList();
            //foreach (var a in context.PropertiesValue.GroupBy(x => x.Value, x=>x.PropertyId).ToList())
            //{
            //    var z = a;
            //}

            return View(model);
        }

        //public ActionResult CreateProduct()
        //{
        //    ProductModel model = new ProductModel
        //    {
        //        Product = new Product(),
        //        Categorys = repository.Categories.ToList()
        //    };
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateProduct(Product p, string CategoryId)
        //{
        //    int catId = Convert.ToInt32(CategoryId);
        //    p.Category = context.Categories.FirstOrDefault(x => x.Id == catId );
        //    context.Products.Add(p);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ViewResult AddNewPropertyValueElement()
        //{
        //    return View("PropertyValue", new PropertyValue());
        //}

        //public ViewResult EditCategory()
        //{
        //    return View();
        //}

    }
}