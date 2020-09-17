using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Models;

namespace Product.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryContext _context;
        public CategoryController(CategoryContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult Index()
        {
            var categorys = _context.Categorys.ToList();
            return View(categorys);
        }

        [HttpGet]
        public ActionResult Create() // GET
        {
            return View("Create", new Categoria());
        }
        [HttpPost]
        public ActionResult Create(Categoria category) // POST
        {
            if (ModelState.IsValid)
            {
                _context.Categorys.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", category);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Categorys = new List<string> { "Nombre"};
            var category = _context.Categorys.Where(o => o.Id == id).FirstOrDefault();

            return View("Edit", category);
        }

        [HttpPost]
        public ActionResult Edit(Categoria category)
        {
            if (ModelState.IsValid)
            {
                _context.Categorys.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = category;
            return View("Edit");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _context.Categorys.Where(o => o.Id == id).FirstOrDefault();
            _context.Categorys.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
