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
        Product GetProductList(int ProductId);
        List<ProductDescription> GetProductDescriptionList();
        List<ProductModel> GetProductModelList();
        List<ProductModelProductDescription> GetProductModelProductDescription();
        void UpdateProductPicture(int productId, byte[] buffer);
        List<Product> ProductSearch(string query);
        Product AddProductUtility(Product newProduct);
        void UpdateProduct(Product newProduct);

    }
}
