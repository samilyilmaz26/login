using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using SamilBeySessionEx.Models;

namespace SamilBeySessionEx.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var basket = SessionHelper.GetObjectFromJson<List<BasketItem>>(HttpContext.Session, "basket");

            if (basket == null)
                return View();

            ViewBag.Total = basket.Sum(i => i.Product.Price * i.Quantity).ToString("c");
            SessionHelper.Count = basket.Count;
            return View(basket);
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<BasketItem>>(HttpContext.Session, "basket") == null)
            {
                var basket = new List<BasketItem>();
                basket.Add(new BasketItem { Product = Data.Products.FirstOrDefault(i=>i.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "basket", basket);
            }
            else
            {
                var basket = SessionHelper.GetObjectFromJson<List<BasketItem>>(HttpContext.Session, "basket");
                int index = isExits(basket, id);
                if (index < 0)
                    basket.Add(new BasketItem { Product = Data.Products.FirstOrDefault(i => i.Id == id), Quantity = 1 });
                else
                    basket[index].Quantity++;

                SessionHelper.SetObjectAsJson(HttpContext.Session, "basket", basket);
            }
            return RedirectToAction("Index");
        }

        private int isExits(List<BasketItem> basket, int id)
        {
            for (int i = 0; i < basket.Count; i++)
            {
                if (basket[i].Product.Id.Equals(id))
                    return i;
            }
            return -1;
        }

        public IActionResult Remove(int id)
        {
            var basket = SessionHelper.GetObjectFromJson<List<BasketItem>>(HttpContext.Session, "basket");
            int index = isExits(basket, id);
            basket.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "basket", basket);
            return RedirectToAction("Index");
        }
    }
}
