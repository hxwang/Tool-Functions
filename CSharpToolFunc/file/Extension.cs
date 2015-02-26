using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shuffling.Model;

namespace Shuffling.Util
{
    public static class Extension
    {
        
        /// <summary>
        /// saved list to file
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fileName"></param>
        public static void SaveToFile(this List<double> list, String fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                list.ForEach(p =>
                {
                    file.WriteLine("{0:0.0000} ",p);
                }
                );
            }
        }


        public static void SaveToFile(this List<List<double>> list, string filename)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
            {
                list.ForEach(p=>
                {
                    file.WriteLine();
                    p.ForEach(s =>
                        {
                            file.Write("{0:0.0000} ",s);
                        });                 
                    
                });
            }
        }
        
        
        /// <summary>
        /// Read line to create double list
        /// </summary>
        public static List<double> ReadList(this StreamReader self)
        {
            var line = self.ReadLine();
            var items = line.Split(' ');
            var list = new List<Double>();
            foreach (String s in items)
            {
                list.Add(double.Parse(s));
            }

            return list;
        
        }

    }
}
