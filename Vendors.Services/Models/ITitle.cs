using System;
using System.Collections.Generic;
using System.Text;

namespace Vendors.Services.Models
{
    public interface ITitle:IModel
    {
        string Name { get; set; }
    }
}
