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
    public class AdminController : Controller
    {
        private EFCategoryRepository CategoryRepository = new EFCategoryRepository();
        private EFProductRepository ProductRepository = new EFProductRepository();
        private EFDbContext context = new EFDbContext();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return RedirectToAction("Categories");
        }

        public ActionResult Categories()
        {
            ViewBag.CategoriesActive = "active";
            return View(CategoryRepository.Categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            ViewBag.CategoriesActive = "active";
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            ViewBag.CategoriesActive = "active";

            if (ModelState.IsValid)
            {
                CategoryRepository.SaveCategory(c);
                return RedirectToAction("Categories", "Admin");
            }
            else return View(c);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var model = CategoryRepository.Categories.FirstOrDefault(x => x.Id == id);
            ViewBag.CategoriesActive = "active";
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            ViewBag.CategoriesActive = "active";

            if (ModelState.IsValid)
            {
                CategoryRepository.SaveCategory(c);
                return RedirectToAction("Categories", "Admin");
            }
            else return View(c);
        }

        public ActionResult DeleteCategory(int id)
        {
            Category c = context.Categories.Find(id);

            if (c == null)
            {
                return HttpNotFound();
            }

            context.Categories.Remove(c);
            context.SaveChanges();

            //CategoryRepository.DeleteCategory(c);
            //return View(c);
            //CategoryRepository.DeleteCategory(id);
            return RedirectToAction("Categories");
        }

        public ViewResult AddNewPropertyElement()
        {
            Property model = new Property();
            //model.Category = repository.Categories.FirstOrDefault(x => x.Id == cat);
            //model.Category = cat;
            return View("Property", model);
        }

        public ActionResult Products()
        {
            ViewBag.ProductsActive = "active";
            return View(context.Products);
        }

        [HttpGet]
        public ActionResult AddProduct(int? ProdId)
        {
            ViewBag.ProductsActive = "active";

            if (ProdId != null)
            {
                Product p = context.Products.Find(ProdId);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    
                    foreach (var pv in p.PropertiesValue)
                    {
                        pv.ProductId = 0;
                    }
                    p.Id = 0; //Занулюэмо Id щоб після зберігання добавлявся новий елемент а не перезатився старий ...
                    ViewBag.CategoryId = p.CategoryId;
                    return View(p);
                }
            }
            else return View(new Product());
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            ViewBag.ProductsActive = "active";

            if (ModelState.IsValid)
            {
                ProductRepository.SaveProduct(p);
                return RedirectToAction("Products", "Admin");
            }
            else return View(p);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var model = ProductRepository.Products.FirstOrDefault(x => x.Id == id);
            ViewBag.CategoryId = model.CategoryId;
            ViewBag.ProductsActive = "active";
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            ViewBag.ProductsActive = "active";

            if (ModelState.IsValid)
            {
                ProductRepository.SaveProduct(p);
                return RedirectToAction("Products", "Admin");
            }
            else return View(p);
        }

        public ActionResult DeleteProduct(int id)
        {
            Product p = context.Products.Find(id);

            if (p == null)
            {
                return HttpNotFound();
            }

            context.Products.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Products");
        }

        public ViewResult AddNewPropertyValueElement(int? CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            PropertyValue model = new PropertyValue();
            return View("PropertyValue", model);
        }
    }
}
