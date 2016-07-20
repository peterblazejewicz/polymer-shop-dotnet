using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            IEnumerable<Category> categories = GetCategories();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
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
            IEnumerable<Category> categories = GetCategories();
            if (categories != null)
            {
                IEnumerable<Category> matched = from c in categories
                                                where c.Name.ToLower() == name.ToLower()
                                                select c;
                Category category = matched.FirstOrDefault();
                if (category != null) return Ok(category);
            }
            return NotFound();
        }

        private IEnumerable<Category> GetCategories()
        {
            string path = Path.Combine(Hosting.ContentRootPath, "Data", "categories.json");
            if (System.IO.File.Exists(path) == true)
            {
                using (StreamReader reader = System.IO.File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    IEnumerable<Category> categories = (IEnumerable<Category>)serializer.Deserialize(reader, typeof(IEnumerable<Category>));
                    return categories;
                }
            }
            return null;
        }

    }
}
