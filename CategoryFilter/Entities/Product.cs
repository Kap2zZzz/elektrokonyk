using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CategoryFilter.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Назва продукту")]
        [Required(ErrorMessage = "Увага!, поле [Назва категорії] не заповнено!")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Короткий опис продукту")]
        [Required(ErrorMessage = "Увага!, поле [Короткий опис продукту] не заповнено!")]
        public string Description { get; set; }

        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "Увага!, поле [Ціна] не заповнено!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Увага!, поле [Ціна] повинно бути більшим 0!")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Увага!, поле [Категорія] не заповнено!")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; } //RelCategory

        public virtual ICollection<PropertyValue> PropertiesValue { get; set; }
    }
}