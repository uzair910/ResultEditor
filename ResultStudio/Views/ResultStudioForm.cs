
using ResultStudio.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResultStudio
{
    public partial class ResultStudioForm : Form
    {
        private const string sIntialDirectoryPath = "..\\Library\\Input";
        private const string sDefaultFileName = "Input_Data1.txt";
        private ParserController pareserController;
        public ResultStudioForm()
        {
            InitializeComponent();
            pareserController = new ParserController();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                fbd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), sIntialDirectoryPath);
                fbd.Filter = "txt files (*.txt)|*.txt";

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    String message;
                    pareserController.ParseFile(fbd.FileName, out message);
                }
            }
        }

        #region Helper methods
   
        #endregion
    }
}
