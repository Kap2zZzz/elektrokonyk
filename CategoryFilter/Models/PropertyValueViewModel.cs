using CategoryFilter.Entities;
using CategoryFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryFilter.Models
{
    public class PropertyValueViewModel
    {
        //private EFDbContext context
        public int? CategoryId { get; set; } //Використовується для того, щоб сформувати правельний випадаючий список по фільтрах які відповідають категорії продуктів.
        public PropertyValue pv { get; set; }
    }
}