using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryFilter.Entities
{
    public class Property
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Назва властивості")]
        [Required(ErrorMessage = "Увага!, поле [Назва властивості] не заповнено!")]
        public string Name { get; set; }

        //public virtual List<PropertyValue> PropertiesValue { get; set; }
        //public virtual ICollection<PropertyValue> PropertiesValue { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
 
    }
}