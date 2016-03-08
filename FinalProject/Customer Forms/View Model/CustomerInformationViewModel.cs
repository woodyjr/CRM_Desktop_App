using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Customer_Forms.View_Model
{
    class CustomerInformationViewModel
    {
        public CustomerInformationViewModel(CustomerInformation custInfo)
        {
            CustomerID = custInfo.CustomerID;
            NameStyle = custInfo.NameStyle;
            Title = custInfo.Title;
            FirstName = custInfo.FirstName;
            MiddleName = custInfo.MiddleName;
            LastName = custInfo.LastName;
            Suffix = custInfo.Suffix;
            CompanyName = custInfo.CompanyName;
            SalesPerson = custInfo.SalesPerson;
            EmailAddress = custInfo.EmailAddress;
            Phone = custInfo.Phone;
            PasswordHash = custInfo.PasswordHash;
            PasswordSalt = custInfo.PasswordSalt;
            AddressID = custInfo.AddressID;
            AddressLine1 = custInfo.AddressLine1;
            AddressLine2 = custInfo.AddressLine2;
            City = custInfo.City;
            StateProvince = custInfo.StateProvince;
            CountryRegion = custInfo.CountryRegion;
            PostalCode = custInfo.PostalCode;
            rowguid = custInfo.rowguid;
            ModifiedDate = custInfo.ModifiedDate;

        }

        public int CustomerID { get; set; }
        public Boolean NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public float PostalCode { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

