//
// https://www.hackerrank.com/tests/7ah6dolcs15/questions/ahi7q7flqrk
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringTest
{
    class SeparateFilenames
    {
        static void Main(string[] args)
        {
            //string filename = Console.ReadLine();
            string filename = "names_list_00.txt";

            FileStream twcf = new FileStream("c_names_list_00.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter twc = new StreamWriter(twcf);
            FileStream twcppf = new FileStream("cpp_names_list_00.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter twcpp = new StreamWriter(twcppf);
            FileStream twcsf = new FileStream("cs_names_list_00.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter twcs = new StreamWriter(twcsf);
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line, extension;
                    while ((line = sr.ReadLine()) != null)
                    {
                        extension = Path.GetExtension(line);
                        if (extension == ".c")
                            twc.WriteLine(line);
                        else if (extension == ".cs")
                            twcs.WriteLine(line);
                        else if (extension == ".cpp")
                            twcpp.WriteLine(line);

                    }
                }
                twc.Close();
                twcs.Close();
                twcpp.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
