using E_Commerce.Controllers.DAL;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cd = new CartDAL();
        public IActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        public IActionResult AddProductToCart(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Cart cart = new Cart();
            cart.Id = id;
            cart.UserId = Convert.ToInt32(userid);
            int res = cd.AddToCart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cd.ViewProductsFromCart(userid);
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            int res = cd.RemoveFromCart(id);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        public IActionResult PlaceOrder(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            var product = db.GetProductById(id);
            return View(product);
        }
        

    }
}
