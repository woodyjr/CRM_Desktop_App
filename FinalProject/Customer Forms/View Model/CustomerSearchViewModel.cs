﻿using CRMSystem.Models;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class CustomerSearchViewModel
    {
        public CustomerSearchViewModel(Customer cust)
        {
            CustomerID = cust.CustomerID;
            NameStyle = cust.NameStyle;
            Title = cust.Title;
            FirstName = cust.FirstName;
            MiddleName = cust.MiddleName;
            LastName = cust.LastName;
            Suffix = cust.Suffix;
            CompanyName = cust.CompanyName;
            SalesPerson = cust.SalesPerson;
            EmailAddress = cust.EmailAddress;
            Phone = cust.Phone;
            PasswordHash = cust.PasswordHash;
            PasswordSalt = cust.PasswordSalt;
            rowguid = cust.rowguid;
            ModifiedDate = cust.ModifiedDate;

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
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
