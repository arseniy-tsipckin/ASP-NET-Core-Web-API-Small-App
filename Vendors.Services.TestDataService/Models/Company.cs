using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class Company : AbstractModel, ICompany
    {

        public string Name { get; set; }
        
        public Location Address { get; set; }
        
        public Contact  Contact{ get; set; }
        [NotMapped]
        ILocation ICompany.Address { get => Address; set => Address=(Location)value; }
        [NotMapped]
        IContact ICompany.Contact { get => Contact; set => Contact=(Contact)value; }
    }
}
