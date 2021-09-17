
using ResultStudio.Common;
using ResultStudio.Controllers;
using ResultStudio.Views;
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
        //private const string sIntialDirectoryPath = "..\\Library\\Input";
        private ResultEditorController resultEditorController;
        private StringBuilder logBuilder;
        // change into a meaningful name
        private Dictionary<int, Vector> data; 
        public ResultStudioForm()
        {
            InitializeComponent();
            resultEditorController = new ResultEditorController();
            logBuilder = new StringBuilder();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                fbd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), Properties.Resources.sIntialDirectoryPath);
                fbd.Filter = "txt files (*.txt)|*.txt";

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    String message;
                    data = resultEditorController.ReadFile(fbd.FileName, out message);
                    logBuilder.Append(message);
                    LoadDataGrid();
                }
            }
        }

        #region Helper methods
        private void LoadDataGrid()
        {
            BindingSource _bindingSource = new BindingSource();
            dataGridView.DataSource = _bindingSource;

            if (data == null)
                return;

            // Need to convert dictionary into a table/array form. Using Linq
            var _priceDataArray = (from entry in data
                                   orderby entry.Key
                                   select new { entry.Key, entry.Value.X, entry.Value.Y, entry.Value.Z }).ToList();
            _bindingSource.DataSource = _priceDataArray;
            // give meaning full name to part id column.. Key doesnt seem suitable.
            dataGridView.Columns["Key"].HeaderText = Properties.Resources.sPartID;


        }
        #endregion

        private void btnLog_Click(object sender, EventArgs e)
        {
            using (var logDialog = new LogForm(logBuilder))
            {
                logDialog.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = logDialog.ShowDialog();
            }
        }
    }
}
