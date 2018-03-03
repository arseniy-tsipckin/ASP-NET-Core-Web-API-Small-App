using System;
using System.Collections.Generic;
using System.Text;

namespace Vendors.Services.Models
{
    public interface IProduct:IModel  
    {
        string Name { get; set; }
        ICategory Category { get; set; }
    }
}
