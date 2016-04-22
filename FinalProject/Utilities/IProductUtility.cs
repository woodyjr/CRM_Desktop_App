using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Utilities
{
    public interface IProductUtility
    {
        List<ProductCategory> GetProductCategoryList();
        List<Product> GetProductList();
        List<ProductDescription> GetProductDescriptionList();
        List<ProductModel> GetProductModelList();
        List<ProductModelProductDescription> GetProductModelProductDescription();
        List<Product> ProductSearch(string query);
        Product AddProductUtility(Product newProduct);

    }
}
