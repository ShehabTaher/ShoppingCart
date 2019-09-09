using ShoppingCart.Models.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CartPartial()
        {
            // Init CartVM
            CartVM model = new CartVM();

            // Init Quantity
            int qty = 0;

            // Init Price
            decimal price = 0;

            // Check for cat session
            if (Session["cart"] != null)
            {
                // Get total qty and price
                var list = (List<CartVM>)Session["cart"];

                foreach (var item in list)
                {
                    qty += item.Quantity; 
                    price += item.Quantity * item.Price;
                }
            }
            else
            {
                // Or set qty and price to 0
                model.Quantity = 0;
                model.Price = 0;
            }

            // Return partial view with model
            return PartialView(model);
        }
    }
}