using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PolymerShopDotnet.Service.Models;
using Swashbuckle.SwaggerGen.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PolymerShopDotnet.Service.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriesController : Controller
    {
        public IHostingEnvironment Hosting { get; }
        public CategoriesController(IHostingEnvironment env)
        {
            Hosting = env;
        }
        // GET api/values
        /// <summary>
        /// Returns list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), 200)]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(int))]
        public IActionResult Get()
        {
            List<Category> categories = new List<Category>();
            return Ok(categories);
        }

        // GET api/categories/mens_outerwear
        /// <summary>
        /// Returns category by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(Category), 200)]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(int))]
        public IActionResult Get(string name)
        {
            Category category = new Category()
            {
                Name = "mens_outerwear",
                Title = "Men\"s Outerwear",
                Image = "/images/mens_outerwear.jpg",
                Placeholder = "data:image/jpeg;base64,/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAAAeAAD/7gAOQWRvYmUAZMAAAAAB/9sAhAAQCwsLDAsQDAwQFw8NDxcbFBAQFBsfFxcXFxcfHhcaGhoaFx4eIyUnJSMeLy8zMy8vQEBAQEBAQEBAQEBAQEBAAREPDxETERUSEhUUERQRFBoUFhYUGiYaGhwaGiYwIx4eHh4jMCsuJycnLis1NTAwNTVAQD9AQEBAQEBAQEBAQED/wAARCAADAA4DASIAAhEBAxEB/8QAXAABAQEAAAAAAAAAAAAAAAAAAAIEAQEAAAAAAAAAAAAAAAAAAAACEAAAAwYHAQAAAAAAAAAAAAAAERMBAhIyYhQhkaEDIwUVNREBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8A3dkr5e8tfpwuneJITOzIcmQpit037Bw4mnCVNOpAAQv/2Q=="
            };
            return Ok(category);
        }

    }
}
