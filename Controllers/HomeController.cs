using Menu_x_Me_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Menu_x_Me_App.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Foods.ToList());
        }

        public ActionResult BurgerMenu()
        {
            return View(db.Foods.ToList());
        }

        public ActionResult PizzaMenu()
        {
            return View(db.Foods.ToList());
        }

        public ActionResult AsianMenu()
        {
            return View(db.Foods.ToList());
        }

        public ActionResult FoodProductView(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        List<Cart> li = new List<Cart>();

        [HttpPost]
        public ActionResult FoodProductView(int Id, string quantity)
        {
            Food food = db.Foods.Find(Id);
            Cart cart = new Cart();
            cart.ProductId = food.Id;
            cart.ProductName = food.Name;
            cart.ProductPic = food.ImageURL;
            cart.Price = food.Price;
            cart.Qty = Convert.ToInt32(quantity);
            cart.Bill = cart.Price * cart.Qty;
            if (TempData["cart"] == null)
            {
                li.Add(cart);
                TempData["cart"] = li;
            }
            else
            {
                //List<Cart> li2 = TempData["cart"] as List<Cart>;
                //li2.Add(cart);
                //TempData["cart"] = li2;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.ProductId == cart.ProductId)
                    {
                        item.Qty += cart.Qty;
                        item.Bill += cart.Bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(cart);
                }
                TempData["cart"] = li2;
            }

            TempData.Keep();
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            TempData.Keep();
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.Bill;
                }
                TempData["total"] = x;
            }
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            List<Cart> li = TempData["cart"] as List<Cart>;

            foreach (var item in li)
            {
                Order odr = new Order();
                odr.FkProdId = item.ProductId;
                odr.Order_Date = System.DateTime.Now;
                odr.Qty = item.Qty;
                odr.Unit_Price = (int)item.Price;
                odr.Order_Bill = item.Bill;
                db.Orders.Add(odr);
                db.SaveChanges();
            }
            TempData.Remove("total");
            TempData.Remove("cart");
            TempData.Keep();
            return RedirectToAction("PlacedOrder");
        }
        public ActionResult ClearShoppingCart()
        {
            List<Cart> li2 = TempData["cart"] as List<Cart>;
            TempData.Remove("total");
            TempData.Remove("cart");
            TempData.Keep();

            return RedirectToAction("Checkout");
        }

        public ActionResult Remove(int? id)
        {
            List<Cart> li2 = TempData["cart"] as List<Cart>;
            Cart c = li2.Where(x => x.ProductId == id).SingleOrDefault();
            li2.Remove(c);
            float h = 0;
            foreach (var item in li2)
            {
                h += item.Bill;
            }
            TempData["total"] = h;
            return RedirectToAction("Checkout");
        }
        public ActionResult PlacedOrder()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}