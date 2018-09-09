using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CategoryFilter.Entities
{
    public class PropertyValue
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Значення властивості")]
        [Required(ErrorMessage = "Увага!, поле [Значення властивості] не заповнено!")]
        public string Value { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; } //RelProduct

        [Required(ErrorMessage = "Увага!, поле [Властивість] не вибрано!")]
        public int? PropertyId { get; set; }
        public virtual Property Property { get; set; } //RelProperty

    }
}