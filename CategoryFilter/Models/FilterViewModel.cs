using CategoryFilter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CategoryFilter.Models
{
    public class FilterViewModel
    {
        //public ICollection<string> Properties { get; set; }
        public string CategoryName { get; set; }
        //public IEnumerable<Product> Products { get; set; }
        //public IEnumerable<Property> Properties { get; set; }
        //public IEnumerable<PropertyValue> PropertiesValue { get; set; }
        public List<Product> Products { get; set; }
        public List<Property> Properties { get; set; }
        public List<PropertyValue> PropertiesValue { get; set; }

        //public List<Data> PropertiesValue2 { get; set; }
        //public ICollection<string> PropertiesValue { get; set; }
    }

    //public struct Data
    //{
    //    public Data(string strValue, int intValue)
    //    {
    //        IntegerData = intValue;
    //        StringData = strValue;
    //    }

    //    public int IntegerData { get; private set; }
    //    public string StringData { get; private set; }
    //}
}