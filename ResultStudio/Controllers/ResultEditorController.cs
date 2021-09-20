using ResultStudio.Common;
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

        public ResultEditorController()
        {
            data = new Dictionary<int, Vector>();
            parser = new ParserController();
        }

        ~ResultEditorController()
        {
        }

        public Dictionary<int, Vector> DataSet { get { return data; } }

     
        public Dictionary<int, Vector> ReadFile(string sfilePath, out string messageLog)
        {
            messageLog = String.Empty;
            // parse data from file and get a dictionary object out of it.
            parser.ParseFile(sfilePath, out messageLog, out data);
            return data;

        }

        public void Clear()
        {
            data = null;
        }

        public object GetResultsList()
        {
            return
                 (from entry in DataSet
                  orderby entry.Key
                  select new { entry.Key, entry.Value.X, entry.Value.Y, entry.Value.Z }).ToList();
        }
    }
}
