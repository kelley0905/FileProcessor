using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileProcessor.DataLayer
{
    public static class Output
    {
        internal static void WriteToFile(List<string> records, string file)
        {
            using (StreamWriter writer = File.CreateText(file))
            {
                foreach (var item in records)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
