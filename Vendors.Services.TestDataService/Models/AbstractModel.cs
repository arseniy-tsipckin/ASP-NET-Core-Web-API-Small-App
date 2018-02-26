using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class AbstractModel : IModel
    {
        public long Id { get ; set ; }
    }
}
