using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session.Web.Extensions;
using Session.Web.Models;
using Session.Web.Services;
using System;
using System.Collections.Generic;

namespace Session.Web.Controllers
{
    public class CartController : Controller
    {
        private IToyService _toyService;
        public CartController(IToyService toyService)
        {
            _toyService = toyService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (HttpContext.Session.Get("cart") == null)
            {
                List<Item> cart = new List<Item>();
                HttpContext.Session.SetObject("cart", cart);
            }
            return View();
        }
        public IActionResult Add(string id)
        {
            if(HttpContext.Session.GetObject<List<Item>>("cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item
                {
                    Toy = _toyService.FindByPrimaryKey(id),
                    Quantity = 1

                });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
                int index = GetItemIndex(cart, id);

                if(index == -1)
                {
                    cart.Add(new Item
                    {
                        Toy = _toyService.FindByPrimaryKey(id),
                        Quantity = 1

                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }
        private int GetItemIndex(List<Item> cart, string id)
        {
            for(int index = 0; index < cart.Count; index++)
            {
                if (cart[index].Toy.CToyId.Equals(id))
                {
                    return index;
                }
            }
            return -1;
        }
        public IActionResult Delete(string id)
        {
            List<Item> cart = HttpContext.Session.GetObject<List<Item>>("cart");
            int index = GetItemIndex(cart, id);

            if( index == -1)
            {
                throw new Exception("Item not found");
            }
            
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);

            return RedirectToAction("Index");
        }
    }
}
