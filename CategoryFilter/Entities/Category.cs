using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryFilter.Entities
{
    public class Category
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Назва категорії")]
        [Required(ErrorMessage = "Увага!, поле [Назва категорії] не заповнено!")]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}