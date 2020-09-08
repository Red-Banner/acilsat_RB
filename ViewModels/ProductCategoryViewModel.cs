using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using acilsat_RB.Models;
namespace acilsat_RB.ViewModels
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}