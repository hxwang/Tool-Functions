using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace OptAssignment
{
    public class FileUtil
    {
        /// <summary>
        /// Write array to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="clientNum"></param>
        /// <param name="insiderNum"></param>
        /// <param name="proxyNum"></param>
        /// <param name="fileName"></param>
        public static void WriteArrayToFile<T>(T[, ,] array, int clientNum, int insiderNum, int proxyNum, string fileName){
            using( System.IO.StreamWriter file = new System.IO.StreamWriter(fileName)){
                //file.WriteLine("{0} {1} {2}", clientNum, insiderNum, proxyNum);
                for(int p=0; p<=proxyNum; p++){
                    for(int n=0; n<=clientNum; n++){
                        for(int m=0; m<=insiderNum; m++){
                            file.Write(array[n,m,p]+" ");
                        }
                    }
                    file.WriteLine();
                }
            }
        }

        //read array from file
        public static T[, ,] ReadArrayFromFile<T>(int clientNum, int insiderNum, int proxyNum, String fileName) {
            String line;
            int proxyIndx = 0;
            var rnt = new T[clientNum + 1, insiderNum + 1, proxyNum + 1];

            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter == null) throw new Exception(string.Format("Unable to convert to type {0}", typeof(T)));

            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName)) {
                while ((line = file.ReadLine()) != null) {
                    String[] items = line.Split(' '); // line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int n = 0; n <= clientNum; n++) {
                        for (int m = 0; m <= insiderNum; m++) {
                            int indx = m * (clientNum+1) + n;
                            rnt[n, m, proxyIndx] = (T)converter.ConvertFrom(items[indx]);
                        }
                    }
                    proxyIndx++;
                }
            }

            return rnt;
        }


    }
}
