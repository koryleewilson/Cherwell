using System.Collections.Generic;
using System.Drawing;
using GeometryProcessor;
using Microsoft.AspNetCore.Mvc;

namespace GeometryApi.Controllers
{
    /// <summary>
    /// Geometry controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class GeometryController : Controller
    {
        /// <summary>
        /// The shapes processor
        /// </summary>
        private readonly IShapesProcessor _shapesProcessor = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryController"/> class.
        /// </summary>
        /// <param name="shapesProcessor">The shapes processor.</param>
        public GeometryController(IShapesProcessor shapesProcessor)
        {
            _shapesProcessor = shapesProcessor;
        }

        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        /// <param name="sRow">The s row.</param>
        /// <param name="nCol">The n col.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("coordinates")]
        public ActionResult GetCoordinates(string row, int col)
        {
            return Ok(_shapesProcessor.GetCoordinates(row, col));
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="v1x">The V1X.</param>
        /// <param name="v1y">The v1y.</param>
        /// <param name="v2x">The V2X.</param>
        /// <param name="v2y">The v2y.</param>
        /// <param name="v3x">The V3X.</param>
        /// <param name="v3y">The v3y.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("location")]
        public ActionResult GetLocation(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            List<Point> coordinates = new List<Point>() { new Point(v1x, v1y), new Point(v2x, v2y), new Point(v3x, v3y) };
            return Ok(_shapesProcessor.GetLocation(coordinates));
        }
    }
}