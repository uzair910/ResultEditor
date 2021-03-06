using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using ResultStudio.Common;
using System.Threading;

namespace ResultStudio.Controllers
{
    public class ParserController
    {
        private const char _sXAxis = 'X';
        private const char _sYAxis = 'Y';
        private const char _sZAxis = 'Z';

        private string _sFilePath = "";
        Dictionary<int, Vector> _data;
        public ParserController()
        {
            _data = new Dictionary<int, Vector>();
        }

        ~ParserController()
        {
        }

        public string FilePath { set { _sFilePath = value; }  }

        public Dictionary<int, Vector> DataSet { get { return _data; } }

        /// <summary>
        /// This method takes the file path that user gives, read the file from that path and then sets data in a meaningful object that the rest of the application can use for interpretation.
        /// </summary>
        /// <param name="sfilePath">The file path that user selects.</param>
        /// <param name="messageLog">The placeholder for outputs that will eventually be passed to log dialog.</param>
        /// <param name="data">The dataset containing all the valid entries that are read from the file.</param>
        public void ParseFile(string sfilePath, out string messageLog, out Dictionary<int, Vector> data)
        {
            messageLog = "Reading data from file:  " + sfilePath;
            // skip line if data is incorrect or the columns don't match
            int iLinesSkipped = 0;
            data = new Dictionary<int, Vector>();
            try
            {
                using (StreamReader file = new StreamReader(sfilePath))
                {
                    // We use separator so it doesn't matter what kind of decimal point is used in the input text files
                    var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    string sLine;
                    while ((sLine = file.ReadLine()) != null)
                    {
                        // Assuming the columns are separated by single space char.
                        string[] sCols = sLine.Split(' ');

                        // Ignore line if its the header.
                        if (null == sCols || sCols.Length != Int32.Parse(Properties.Resources.iInputFileDefaultColumnLength) || sCols[0].ToUpper() == Properties.Resources.sMeasurementText.ToUpper())
                        {
                            messageLog += "Line skipped. \nEither it contained Header text or it had invalid format.";
                            continue;
                        }

                        int iPartID;
                        char sAxis;
                        double dValue;
                        // partID will be zero incase the first column is anything but a number/decimal. 
                        Int32.TryParse(sCols[0], out iPartID);
                        Char.TryParse(sCols[1].ToUpper(), out sAxis);
                        Double.TryParse(Regex.Replace(sCols[2], "[.,]", separator), out dValue);

                        // Skip parsing if the columns length is not equal to 3. Or if the part id is 0.
                        if (iPartID == 0 || sAxis == '\0' )
                        {
                            messageLog += "\nSKIPPIED LINES: Error in reading the line: " + sLine;
                            iLinesSkipped++;
                            continue;
                        }

                        // For each measurement, there should exist 3 value, for axis x,y and z. Lets confirm that.
                        // if partID already exists in the list, then add the coordinate. Otherwise, insert the part and the coordinate.
                        if (data.ContainsKey(iPartID))
                        {
                            Vector v = data[iPartID];
                            AssignVectorValue(sAxis, dValue, ref v);
                            data[iPartID] = v;
                        }
                        else
                        {
                            // part not already added to the model, lets add it now, along with the value. 
                            Vector v = new Vector();
                            AssignVectorValue(sAxis, dValue, ref v);
                            data.Add(iPartID, v);
                        }
                    }
                    file.Close();
                }
            }
            catch (Exception e)
            {
                messageLog = "ERROR: Crash! Error thrown: \n" + e.ToString();
                return;
            }
            finally
            {
                messageLog += "File read complete.\nTotal entries skipped: " + iLinesSkipped;
            }
        }

        #region helper methods
        private void AssignVectorValue(char sAxis, double dValue, ref Vector v)
        {
            switch (sAxis)
            {
                case _sXAxis:
                    v.X = dValue;
                    break;
                case _sYAxis:
                    v.Y = dValue;
                    break;
                case _sZAxis:
                    v.Z = dValue;
                    break;
            }
        }

        public string ParsingTask()
        {
            string messagelog = string.Empty;
            ParseFile(_sFilePath, out messagelog, out _data);
            Thread.Sleep(5000);
            return messagelog;
        }
        #endregion


    }
}
