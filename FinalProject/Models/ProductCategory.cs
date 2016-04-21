using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public int ParentProductCategoryID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid rowguid { get; set; }
    }
}
