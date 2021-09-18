using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultStudio.Common
{
    // Containing a selection of filtered chart views. 
    // Picked from hit and trail on which representaiton make sense.
    public enum FilteredSeriesChartType
    {
        //
        // Summary:
        //     Point chart type.
        Point = 0,
        //
        // Summary:
        //     FastPoint chart type.
        FastPoint = 1,
        //
        // Summary:
        //     Bubble chart type.
        Bubble = 2,
        //
        // Summary:
        //     Line chart type.
        Line = 3,
        //
        // Summary:
        //     Spline chart type.
        Spline = 4,
        //
        // Summary:
        //     StepLine chart type.
        StepLine = 5,
        //
        // Summary:
        //     FastLine chart type.
        FastLine = 6,
        //
        // Summary:
        //     Bar chart type.
        Bar = 7,
        //
        // Summary:
        //     Stacked bar chart type.
        StackedBar = 8,
        //
        // Summary:
        //     Area chart type.
        Area = 9,
        //
        // Summary:
        //     Spline area chart type.
        SplineArea = 10,
        //
        // Summary:
        //     Candlestick chart type.
        Candlestick = 11,
        //
        // Summary:
        //     Range chart type.
        Range = 12,
        //
        // Summary:
        //     Spline range chart type.
        SplineRange = 13,
        //
        // Summary:
        //     RangeBar chart type.
        RangeBar = 14,
        //
        // Summary:
        //     Range column chart type.
        RangeColumn = 15,
        //
        // Summary:
        //     Radar chart type.
        Radar = 16,
    }
}
