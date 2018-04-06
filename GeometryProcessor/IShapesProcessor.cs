using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GeometryProcessor
{
    /// <summary>
    /// ShapesProcessor interface
    /// </summary>
    public interface IShapesProcessor
    {
        List<Point> GetCoordinates(string sRow, int nCol);
        Dictionary<string, int> GetLocation(List<Point> coordinates);
    }
}
