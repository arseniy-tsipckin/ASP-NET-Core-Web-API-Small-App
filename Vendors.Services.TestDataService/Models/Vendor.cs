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
        public Title Title { get; set ; }
        public Company Company { get; set ; }
        public Contact Contact { get ; set ; }
        [NotMapped]
        ITitle IVendor.Title { get => Title; set => Title=(Title)value; }
        [NotMapped]
        ICompany IVendor.Company { get => Company; set => Company=(Company)value; }
        [NotMapped]
        IContact IVendor.Contact { get => Contact; set => Contact=(Contact)value; }
    }
}
