/*using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;


public class CartController : Controller
{
    private TopG_clothingEntities db = new TopG_clothingEntities();
    public ActionResult Index()
    {
        // Assuming you have a way to identify the current user
        int userId = 1; 

        // Retrieve cart items for the specific user
        List<cartItem> cart_Items = db.cartItems.Where(c => c. == userId).ToList();

        return View(cart_Items);
    }


    [HttpPost]
    public ActionResult RemoveFromCart(int productId)
    {
        // Find the cart item to remove
        var cartItemToRemove = db.Cart_item.Find(productId);

        if (cartItemToRemove != null)
        {
            // Remove the item from the cart
            db.Cart_item.Remove(cartItemToRemove);
            db.SaveChanges();
        }

        // Redirect back to the cart page
        return RedirectToAction("Index");
    }


    [HttpPost]
    public ActionResult UpdateQuantity(int productId, string operation)
    {
        try
        {
            var cartItem = db.Cart_item.Find(productId);

            if (cartItem != null)
            {
                if (operation == "plus")
                {
                    cartItem.cartItem_product_qty++;
                }
                else if (operation == "minus" && cartItem.cartItem_product_qty > 1)
                {
                    cartItem.cartItem_product_qty--;
                }

                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = "Product not found" });
            }
        }
        catch (Exception ex)
        {
            // Log the exception or output details for debugging
            Console.WriteLine(ex.ToString());

            // Return a generic error response
            return Json(new { success = false, error = "An error occurred on the server." });
        }
    }
}*/