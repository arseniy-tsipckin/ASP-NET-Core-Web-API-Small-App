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
        [NotMapped]
        public ILocation Address{ get =>AddressField;set =>value=AddressField; }
        public Location AddressField { get; set; }
        [NotMapped]
        public IContact Contact { get =>ContactField; set =>value=ContactField; }
        public Contact  ContactField{ get; set; }

    }
}
