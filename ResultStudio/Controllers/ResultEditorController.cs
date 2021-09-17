using ResultStudio.Common;
using ResultStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultStudio.Controllers
{
    public class ResultEditorController
    {
        private Dictionary<int, Vector> data;
        private ParserController parser;
        public void ReadFile(string sfilePath, out string messageLog)
        {
            messageLog = String.Empty;

            parser.ParseFile(sfilePath, out messageLog, out data);


        }
    }
}
