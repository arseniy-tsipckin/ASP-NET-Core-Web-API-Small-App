using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendors.Services.TestDataService.Models
{
    public class Vendor : AbstractModel, IVendor
    {
        public string FirstName { get ; set ; }
        public string LastName { get; set ; }
        public Title TitleField { get; set ; }
        public Company CompanyField { get; set ; }
        public Contact ContactField { get ; set ; }
        [NotMapped]
        public ITitle Title { get => TitleField; set => value=TitleField; }
        [NotMapped]
        public ICompany Company { get => CompanyField; set => value=CompanyField; }
        [NotMapped]
        public IContact Contact { get => ContactField; set => value=ContactField; }
    }
}
