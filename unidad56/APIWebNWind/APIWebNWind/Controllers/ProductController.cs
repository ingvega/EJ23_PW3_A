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
        [Route("GetNameAndPrice")]
        public IEnumerable<object> GetNameAndPrice()
        {
            IEnumerable<object> lista =
                from producto in contexto.Products
                select new
                {
                    Name = producto.ProductName,
                    Price = producto.UnitPrice,
                    Category=producto.Category.CategoryName
                };

            return lista;
        }

        [HttpGet]
        [Route("GetNameAndPrice2")]
        public IEnumerable<Product> GetNameAndPrice2()
        {
            Product p= new Product()
            {
                ProductName = "A",
                UnitPrice = 1
            };

            Product p1 = new Product();
            p1.ProductName = "A";
            p1.UnitPrice = 1;
            


            IEnumerable<Product> listaP =
                from producto in contexto.Products
                select new Product()
                {
                    ProductName = producto.ProductName,
                    UnitPrice = producto.UnitPrice
                };
            return listaP;
        }


    }
}
