using ResultStudio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResultStudio.Models
{
    public class MeasurementDataModel
    {
        private int iPartID;
        private Vector vectorValue;

        public int PartID { get => iPartID; set => iPartID = value; }

        public void Assign(int partID, double xVal, double yVal, double zVal)
        {
            this.iPartID = partID;
            vectorValue = new Vector(xVal, yVal, zVal);
        }

    }
}
