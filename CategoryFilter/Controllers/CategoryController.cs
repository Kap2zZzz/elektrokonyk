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

    public class CategoryController : Controller
    {
        private EFCategoryRepository repository = new EFCategoryRepository();
        private EFDbContext context = new EFDbContext();

        public ActionResult Index()
        {
            return View(new Category());
        }

        //[HttpPost]
        //public ActionResult Index(Category cat)
        //{
        //    repository.SaveCategory(cat);
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult Edit(int id)
        //{
        //    var model = repository.Categories.FirstOrDefault(x => x.Id == id);
        //    //EditViewModel model = new EditViewModel();
        //    //model.cat = repository.Categories.FirstOrDefault(x => x.Id == id);
        //    //model.RemoveId = new List<int>();
        //    //Category model = repository.Categories.FirstOrDefault(x => x.Id == id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(Category c)
        //{
        //    repository.SaveCategory(c);
        //    return RedirectToAction("Index", "Home");
        //}

        //public ViewResult AddNewPropertyElement()
        //{
        //    Property model = new Property();
        //    //model.Category = repository.Categories.FirstOrDefault(x => x.Id == cat);
        //    //model.Category = cat;
        //    return View("Property", model);
        //}

    }
}
