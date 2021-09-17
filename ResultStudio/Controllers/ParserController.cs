using ResultStudio.Models;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace ResultStudio.Controllers
{
    public class ParserController
    {
        private ArrayList measurements;
        public ArrayList<MeasurementDataModel> list = new ArrayList<>();
        public void ParseFile(string sfilePath, out string message)
        {
            try
            {
                message = "Hello World " + sfilePath;
                using (StreamReader file = new StreamReader(sfilePath))
                {
                    int iLinesSkipped = 0; // skip line if data is incorrect or the columns don't match
                    string sLine;
                    while ((sLine = file.ReadLine()) != null)
                    {
                        string[] sCols = sLine.Split(' '); // Assuming the columns are separated by single space char.
                       
                        // Ignore if the first line includes header text
                        if (sCols[0] == Properties.Resources.sAxisY)
                        {
                            continue; // Skip parse process for this line.
                        }
                        // Skip parsing if the columns mismatch
                        if (sCols.Length != Int32.Parse(Properties.Resources.iInputFileDefaultColumnLength)) // Parse not exactly super safe. 
                        {
                            iLinesSkipped++;
                            continue;
                        }

                        // here comes the tricky part.. 
                        // For each measurement, there should exist 3 value, for axis x,y and z. Lets confirm that.




                        Console.WriteLine(sLine);
                    }
                    file.Close();
                }
            }
            catch (Exception e)
            {
                message = "Crash!\n" + e.ToString();
                return;
            }
        }
    }
}
