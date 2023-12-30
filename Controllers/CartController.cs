using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;


public class CartController : Controller
{
    private TopG_clothingEntities1 db = new TopG_clothingEntities1();

    public ActionResult Index()
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();

        // Retrieve cart items for the specific user
        List<Cart_item> cart_Items = db.Cart_item.Where(c => c.User_id == userId).ToList();

        return View(cart_Items);
    }

    [HttpPost]
    public ActionResult AddToCart(int productId)
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();

        // Check if the product is already in the cart
        var existingCartItem = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

        if (existingCartItem != null)
        {
            // Increment quantity if the product is already in the cart
            existingCartItem.cartItem_product_qty++;
            db.SaveChanges();
        }
        else
        {
            // Add a new item to the cart if not already in the cart
            Cart_item newCartItem = new Cart_item
            {
                User_id = userId,
                product_id = productId,
                cartItem_product_qty = 1  // You can set the initial quantity as needed
            };

            db.Cart_item.Add(newCartItem);
            db.SaveChanges();

        }


        // Redirect back to the product page or wherever you want
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult RemoveFromCart(int productId)
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();

        // Find the cart item to remove
        var cartItemToRemove = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

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
            // Assuming you have a way to identify the current user
            int userId = GetCurrentUserId();

            var cartItem = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

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
                return Json(new { success = false, error = "Product not found in the user's cart" });
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

    private int GetCurrentUserId()
    {
        // Replace this with your logic to get the current user's ID
        // Example: Retrieve user ID from session
        if (Session["Per_person"] != null && int.TryParse(Session["Per_person"].ToString(), out int userId))
        {
            return userId;
        }

        // Default value if user ID is not available
        return 0;
    }
}
