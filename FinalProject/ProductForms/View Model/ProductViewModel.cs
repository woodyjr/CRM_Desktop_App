using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ProductForms.View_Model
{
    class ProductViewModel
    {
        public ProductViewModel(Product prod)
        {
            ProductID = prod.ProductID;
            Name = prod.Name;
            ProductNumber = prod.ProductNumber;
            Color = prod.Color;
            StandardCost = prod.StandardCost;
            ListPrice = prod.ListPrice;
            Size = prod.Size;
            Weight = prod.Weight;
            ProductCategoryID = prod.ProductCategoryID;
            ProductModelID = prod.ProductModelID;
            SellStartDate = prod.SellStartDate;
            SellEndDate = prod.SellEndDate;
            DiscontinuedDate = prod.DiscontinuedDate;
            ThumbNailPhoto = prod.ThumbNailPhoto;
            ThumbnailPhotoFileName = prod.ThumbnailPhotoFileName;
            rowguid = prod.rowguid;
            ModifiedDate = prod.ModifiedDate;
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
