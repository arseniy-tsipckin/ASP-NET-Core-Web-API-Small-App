using System;
using System.Collections.Generic;
using System.Text;

namespace Vendors.Services.Models
{
    public interface ICategory:IModel
    {
        string Name { get; set; }
        ICollection<IProduct> Products { get; set; }
    }
}
