using FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class DependencyInjectorUtility
    {
        public static Data.ICustomerUtility GetCustomerUtility()
        {
            //return new DbCustomerUtility();
            return new Data.DbCustomerUtility();   
        }
        public static Utilities.IProductUtility GetProductsUtility()
        {
            return new Utilities.DbProductUtility();
        }
        public static IOrderUtility GetOrdersUtility()
        {
            return new DbOrderUtility();
        }
    }
}
