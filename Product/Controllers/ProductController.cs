using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product.Models;

namespace Product.Controllers
{
    
    public class ProductController : Controller
    {
        private ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
           // var model = _context.Categorys.Include(o => o.Categoría).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create() // GET
        {
            return View("Create", new Producto());
        }
        [HttpPost]
        public ActionResult Create(Producto product) // POST
        {
           if (ModelState.IsValid)
           {
               _context.Products.Add(product);
               _context.SaveChanges();
               return RedirectToAction("Index");
           }
            return View("Create", product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Products = new List<string> { "Nombre", "Categoria", "Proveedor","Costo" };
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();

            return View("Edit", product);
        }

        [HttpPost]
        public ActionResult Edit(Producto product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = product;
            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Where(o => o.Id == id).FirstOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
