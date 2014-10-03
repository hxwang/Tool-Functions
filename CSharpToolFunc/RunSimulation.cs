using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shuffling.Util;
using Shuffling.Model;
using System.Reflection;

namespace Shuffling.Simulations
{
    public class RunSimulation
    {
        public static ISimulator GetSimulator(string name)
        {
            // get the type of the interface
            var type = typeof(ISimulator);
            // query all the classes that implement IMyInterface in current assembly
            // t.IsClass is very important, otherwise you will get more interface types 
            // that inherited IMyInterface, include IMyInterface itself
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && type.IsAssignableFrom(t)
                    select t;
            // convert the query result to list (List<type>)
            var classes = q.ToList();
            // find the one we need
            var myClass = classes.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            // create an instance from a type
            var instance = (ISimulator)Activator.CreateInstance(myClass);
            // return the created instance       
            return instance;
        }
        

    }
}
