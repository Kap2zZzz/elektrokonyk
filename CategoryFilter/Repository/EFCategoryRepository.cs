using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CategoryFilter.Repository
{
    public class EFCategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Categories { get { return context.Categories; } }

        public void SaveCategory(Category cat)
        {
            using (context)
            {
                //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                if (cat.Id == 0)
                {
                    context.Categories.Add(cat);
                }
                else
                {
                    //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;

                    foreach (var p in cat.Properties)
                    {
                        context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                        //Якщо ID властивості = 0 - значить це нова властивість. Добавляємо її до БД.
                        if (p.Id == 0)
                        {
                            //p.Category = cat;
                            //context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                            p.CategoryId = cat.Id;
                            context.Properties.Add(p);
                        }
                    }

                    //Видалення з БД елементів, які відсутні на формі
                    List<Property> PropertiesForm = cat.Properties.ToList();
                    List<Property> PropertiesDB = context.Properties.Where(x => x.Category.Id == cat.Id).ToList(); //Отримуємо актуальний перелік елементів які ще є в БД за цією категорією
                    foreach (var p_db in PropertiesDB)
                    {
                        //Шукаємо властивість на формі, ID якої == ID властивості в БД
                        Property a = PropertiesForm.FirstOrDefault(x => x.Id == p_db.Id);
                        //Якщо такої властивості не знайдено на формі - значить її видалено, відповідно видаляємо її з БД 
                        if (a == null)
                        {
                            context.Properties.Remove(p_db);
                        }
                    }
                    context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                }
                //context.Categories.Attach(cat);
                //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            Category c = context.Categories.Find(id);
            if (c != null)
            {
                using (context)
                {
                    context.Categories.Remove(c);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCategory(Category c)
        {
            using (context)
            {
                //context.Categories.Attach(c);
                context.Entry(c).State = EntityState.Deleted;
                //context.Categories.Remove(c);
                context.SaveChanges();
            }
        }
    }
}