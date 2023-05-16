using Microsoft.AspNetCore.Mvc;
using APIWebNWind.Data;
using APIWebNWind.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace APIWebNWind.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly NorthwindContext contexto;

        public ProductController(NorthwindContext context)
        {
            contexto = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return contexto.Products.OrderBy(p => p.ProductName);

        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            var result = await contexto.Products.OrderBy(p => p.ProductName).ToListAsync();

            
            return Ok(result);

        }
    }
}
