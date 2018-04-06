using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GeometryProcessor
{
    /// <summary>
    /// Geometry Processor
    /// </summary>
    /// <seealso cref="GeometryProcessor.IShapesProcessor" />
    public class ShapesProcessor : IShapesProcessor
    {
        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <param name="sRow">The row.</param>
        /// <param name="nCol">The col.</param>
        /// <returns></returns>
        public List<Point> GetCoordinates(string sRow, int nCol)
        {
            List<Point> ret = new List<Point>();
            int nRow = (int)Enum.Parse(typeof(Rows), sRow);

            if (nCol % 2 == 0)
            {
                //top
                nCol = (nCol / 2) - 1;
                ret.Add(new Point(nCol * 10, nRow * 10));
                ret.Add(new Point((nCol + 1) * 10, nRow * 10));
                ret.Add(new Point((nCol + 1) * 10, (nRow + 1) * 10));
            }
            else
            {
                //bottom
                nCol = Convert.ToInt32(Math.Floor(Convert.ToDouble(nCol) / 2));
                ret.Add(new Point(nCol * 10, nRow * 10));
                ret.Add(new Point(nCol * 10, (nRow + 1) * 10));
                ret.Add(new Point((nCol + 1) * 10, (nRow + 1) * 10));
            }

            return ret;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <returns></returns>
        public Dictionary<string, int> GetLocation(List<Point> coordinates)
        {
            // determine the row
            int nRow = (Math.Max(coordinates[0].Y, Math.Max(coordinates[1].Y, coordinates[2].Y)) / 10) - 1;

            // find the numeric column
            int nColMax = Math.Max(coordinates[0].X, Math.Max(coordinates[1].X, coordinates[2].X));

            // translate to the grid column
            int nCol = coordinates.Count(p2 => p2.X == nColMax) == 2 ? (nColMax / 10) * 2 : ((nColMax / 10) * 2) - 1;

            // name of the row
            string sRow = Enum.GetName(typeof(Rows), nRow);

            return new Dictionary<string, int> { { sRow, nCol } };
        }
    }


}
