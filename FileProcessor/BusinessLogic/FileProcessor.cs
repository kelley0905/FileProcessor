using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileProcessor.DataLayer;

namespace FileProcessor.BusinessLogic
{
    public static class FileProcessor
    {
        internal static string ProcessFile(string fileName, string delimiterType, int fieldNumber)
        {
            var correctFile = fileName.Replace(".txt", "_CorrectFile.txt");
            var incorrectFile = fileName.Replace(".txt", "_IncorrectFile.txt");
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    List<string> correctRecords = new List<string>();
                    List<string> incorrectRecords = new List<string>();
                    var headerRecord = true;
                    while (!reader.EndOfStream)
                    {
                        //Get the record
                        string record = reader.ReadLine();
                        if (headerRecord)
                        {
                            headerRecord = false;
                            continue;
                        }
                        //Process the record
                        ProcessRecord(record, delimiterType, fieldNumber, correctRecords, incorrectRecords);
                    }
                    //Send to appropriate file
                    if (correctRecords.Count > 0)
                    {
                        Output.WriteToFile(correctRecords, correctFile);
                    }
                    if (incorrectRecords.Count > 0)
                    {
                        Output.WriteToFile(incorrectRecords, incorrectFile);
                    }
                }
                return "File processed successfully";
            }
            catch (FileNotFoundException)
            {
                return "The input file could not be found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void ProcessRecord(string record, string delimiterType, int fieldNumber, 
            List<string> correctRecords, List<string> incorrectRecords)
        {
            string[] recordParts;
            if (delimiterType == "tsv")
            {
                recordParts = record.Split('\t');
            }
            else
            {
                recordParts = record.Split(',');
            }

            if (recordParts.Length == fieldNumber)
            {
                correctRecords.Add(record);
            }
            else
            {
                incorrectRecords.Add(record);
            }
        }
    }
}
