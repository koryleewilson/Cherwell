using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeometryApi.Controllers
{
    [Route("api/[controller]")]
    public class GeometryController : Controller
    {
        private enum rows
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5
        };

        [HttpGet]
        public ActionResult GetCoordinates(string sRow, int nCol)
        {
            List<Point> ret = new List<Point>();
            int nRow = (int)Enum.Parse(typeof(rows), sRow);

            if (nCol % 2 == 0)
            {
                //top
                ret.Add(new Point(nRow * 10, ((nCol / 2) - 1) * 10));
                ret.Add(new Point((nRow * 10) + 10, ((nCol / 2) - 1) * 10));
                ret.Add(new Point((nRow * 10) + 10, (((nCol / 2) - 1) * 10) + 10));
            }
            else
            {
                //bottom
                nCol = Convert.ToInt32(Math.Floor(Convert.ToDouble(nCol / 2)));
                ret.Add(new Point(nRow * 10, nCol * 10));
                ret.Add(new Point(nRow * 10, (nCol * 10) + 10));
                ret.Add(new Point((nRow * 10) + 10, (nCol * 10) + 10));
            }

            return Ok(ret);
        }

        [HttpGet]
        public ActionResult GetLocation(List<Point> coordinates)
        {
            int row = Math.Max(coordinates[0].Y, Math.Max(coordinates[1].Y, coordinates[2].Y)) / 10;

            int colMax = Math.Max(coordinates[0].X, Math.Max(coordinates[1].X, coordinates[2].X));

            int col = coordinates.Count(p2 => p2.X == colMax) == 2 ? (colMax / 10) * 2 : ((colMax / 10) * 2) - 1;

            return Ok(new Point(col, row));
        }
    }
}