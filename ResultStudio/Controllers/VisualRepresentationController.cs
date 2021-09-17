using ResultStudio.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ResultStudio.Controllers
{
    public class VisualRepresentationController
    {
        private Dictionary<int, Vector> dicData;
        private BindingSource data;
        public VisualRepresentationController()
        {
        }

        public BindingSource DataSource
        {
            set { this.data = value; }
        }

        public Dictionary<int, Vector> Dictionary
        {
            set { this.dicData = value; }
        }

        public void PopulatePointDistributionGraph(ref Chart canvasChart, out string messageLog)
        {
            messageLog = string.Empty;
            if (data == null)
            {
                messageLog = Properties.Resources.sErrNoData;
            }

            canvasChart.Series[0].XValueMember = "PartID";
            canvasChart.Series[0].YValueMembers = "PartID";


            canvasChart.Series[1].XValueMember = "X";
            canvasChart.Series[1].YValueMembers = "X";


            canvasChart.Series[2].XValueMember = "Y";
            canvasChart.Series[2].YValueMembers = "Y";

            foreach (KeyValuePair<int, Vector> part in dicData)
            {
                canvasChart.Series[0].Points.AddXY(part.Key, part.Value.X);
                canvasChart.Series[1].Points.AddXY(part.Key, part.Value.Y);
                canvasChart.Series[2].Points.AddXY(part.Key, part.Value.Z);
            }
            SetChartStyle(ref canvasChart);


        }

        private void SetChartStyle(ref Chart canvasChart)
        {
            canvasChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            canvasChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            canvasChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            canvasChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            canvasChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            canvasChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            canvasChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            canvasChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            canvasChart.ChartAreas[0].CursorX.Interval = 0.01;

            // For all the data, since the Y axis becomes too big, its better to view labels
            //canvasChart.Series[0].IsValueShownAsLabel = true;
            //canvasChart.Series[1].IsValueShownAsLabel = true;
            //canvasChart.Series[2].IsValueShownAsLabel = true;
        }
    }
}
