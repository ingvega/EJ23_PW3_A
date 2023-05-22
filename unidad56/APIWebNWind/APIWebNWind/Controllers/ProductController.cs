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

        /*
         Obtener el nombre del producto, categoría (nombre), existencia de todos los productos que estan activos con el uso de JOIN
       
         */

        [HttpGet]
        [Route("GetProductsNodiscontinued")]
        public IEnumerable<object> GetProductsNodiscontinued()
        {
            var result =
                from c in contexto.Categories
                join p in contexto.Products on c.CategoryId equals p.CategoryId
                where p.Discontinued == false
                select new
                {
                    Nombre=p.ProductName,
                    Categoria=c.CategoryName,
                    Existencias=p.UnitsInStock
                };
            return result;
        }

        [HttpGet]
        [Route("GetProductsNodiscontinued2")]
        public IEnumerable<object> GetProductsNodiscontinued2()
        {
            var result = contexto.Products
                .Where(p=>p.Discontinued==false)
                .Join(contexto.Categories,
                     (p) => p.CategoryId,
                     (c) => c.CategoryId,
                     (p, c) =>
                         new
                         {
                             Nombre = p.ProductName,
                             Categoria = c.CategoryName,
                             Existencias = p.UnitsInStock
                         }
                     );

            return result;


            //var result = contexto.Categories.
            //    Join(contexto.Products,
            //         (c) => c.CategoryId,
            //         (p) => p.CategoryId,
            //         (c, p) => 
            //             new
            //             {
            //                 Nombre = p.ProductName,
            //                 Categoria = c.CategoryName,
            //                 Existencias = p.UnitsInStock,
            //                 Activo= !p.Discontinued
            //             }
            //         )
            //    .Where(p=> p.Activo );

            //return result;
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

        [HttpGet]
        [Route("GetInventarioCategoria")]
        public IEnumerable<object> GetInventarioCategoria()
        {
            IEnumerable<object> lista =
                contexto.Products.
                Join(contexto.Categories,
                (p)=>p.CategoryId,
                (c) => c.CategoryId,
                (p, c)=>
                    new
                    {
                        Categoria = c.CategoryName,
                        Existencia = p.UnitPrice
                    }
                ).GroupBy(pc=>pc.Categoria)
                .Select(grupo=>
                    new { 
                        Categoria=grupo.Key,
                        Inventario=grupo.Sum(g=>g.Existencia)
                    }
                );

            return lista;
        }

    }
}
