using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class Title: AbstractModel,ITitle
    {
       public string Name { get; set; }
    }
}
