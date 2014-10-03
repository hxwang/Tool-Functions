using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shuffling.Model;

namespace Shuffling.Util
{
    public static class Extension
    {
        //public static double GetValue(this MWArray self, int i, int j)
        //{
        //   return ((MWNumericArray)self[i,j]).ToScalarDouble();
        //}


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

        public static List<Client> ClientLeaveSystem(this List<Client> self, double processingTime)
        {
            var list = self.Where(c =>
            {
                return !c.IsInsider && c.AttackedHistory.Count > processingTime;
            }).ToList();

            self.RemoveAll(c =>
            {
                return !c.IsInsider && c.AttackedHistory.Count > processingTime;
            });

            return list;
        }


    }
}
