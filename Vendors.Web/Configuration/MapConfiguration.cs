using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Vendors.API.Configuration
{
    public class MapConfiguration
    {

        public static Assembly[] Profiles
        {
            get
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().ToList();
                
                return (from a in assembly
                        from t in a.GetTypes()
                        where t.IsSubclassOf(typeof(Profile)) && !t.IsAbstract && t.Namespace.StartsWith("Vendor")
                        select t.Assembly).ToArray();
            }
        }
            
                                      

    }
}
