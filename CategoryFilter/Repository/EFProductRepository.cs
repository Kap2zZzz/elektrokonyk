using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryFilter.Repository
{
    public class EFProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products { get { return context.Products; } }

        public void SaveProduct(Product prod)
        {
            using (context)
            {
                //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                if (prod.Id == 0)
                {
                    context.Products.Add(prod);
                }
                else
                {
                    //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;

                    foreach (var p in prod.PropertiesValue)
                    {
                        context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                        //Якщо ID властивості = 0 - значить це нова властивість. Добавляємо її до БД.
                        if (p.Id == 0)
                        {
                            //p.Category = cat;
                            //context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                            p.ProductId = prod.Id;
                            context.PropertiesValue.Add(p);
                        }
                    }

                    //Видалення з БД елементів, які відсутні на формі
                    List<PropertyValue> PropertiesForm = prod.PropertiesValue.ToList();
                    List<PropertyValue> PropertiesDB = context.PropertiesValue.Where(x => x.Product.Id == prod.Id).ToList(); //Отримуємо актуальний перелік елементів які ще є в БД за цією категорією
                    foreach (var p_db in PropertiesDB)
                    {
                        //Шукаємо властивість на формі, ID якої == ID властивості в БД
                        PropertyValue pv = PropertiesForm.FirstOrDefault(x => x.Id == p_db.Id);
                        //Якщо такої властивості не знайдено на формі - значить її видалено, відповідно видаляємо її з БД 
                        if (pv == null)
                        {
                            context.PropertiesValue.Remove(p_db);
                        }
                    }
                    context.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                }
                //context.Categories.Attach(cat);
                //context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}