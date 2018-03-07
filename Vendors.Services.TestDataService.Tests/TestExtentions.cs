using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;
using System.Linq;
using System.Reflection;

namespace Vendors.Services.TestDataService.Tests
{
    public static class TestExtentions
    {
        public static bool EqualsToModel(this IModel thisModel,IModel model)
        {
            if(model==null)
            {
                return false;
            }
            foreach(var thisProp in thisModel.GetType().GetProperties())
            {
                var prop = model.GetType().GetProperty(thisProp.Name);
                if(prop==default(PropertyInfo))
                {
                    return false;
                }
                var expectedValue=thisProp.GetMethod.Invoke(thisModel, null);
                var actualValue = prop.GetMethod.Invoke(model, null);
                if(!actualValue.Equals(expectedValue))
                {
                    return false;
                }
            }
            return true;
            
        }

       
    }
}
