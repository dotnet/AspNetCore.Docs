using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
  public class ShoppingCartActions : IDisposable
  {
    public string ShoppingCartId { get; set; }

    private ProductContext _db = new ProductContext();

    public const string CartSessionKey = "CartId";

    public void AddToCart(int id)
    {
      // Retrieve the product from the database.           
      ShoppingCartId = GetCartId();

      var cartItem = _db.ShoppingCartItems.SingleOrDefault(
          c => c.CartId == ShoppingCartId
          && c.ProductId == id);
      if (cartItem == null)
      {
        // Create a new cart item if no cart item exists.                 
        cartItem = new CartItem
        {
          ItemId = Guid.NewGuid().ToString(),
          ProductId = id,
          CartId = ShoppingCartId,
          Product = _db.Products.SingleOrDefault(
           p => p.ProductID == id),
          Quantity = 1,
          DateCreated = DateTime.Now
        };

        _db.ShoppingCartItems.Add(cartItem);
      }
      else
      {
        // If the item does exist in the cart,                  
        // then add one to the quantity.                 
        cartItem.Quantity++;
      }
      _db.SaveChanges();
    }

    public void Dispose()
    {
      if (_db != null)
      {
        _db.Dispose();
        _db = null;
      }
    }

    public string GetCartId()
    {
      if (HttpContext.Current.Session[CartSessionKey] == null)
      {
        if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
        {
          HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
        }
        else
        {
          // Generate a new random GUID using System.Guid class.     
          Guid tempCartId = Guid.NewGuid();
          HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
        }
      }
      return HttpContext.Current.Session[CartSessionKey].ToString();
    }

    public List<CartItem> GetCartItems()
    {
      ShoppingCartId = GetCartId();

      return _db.ShoppingCartItems.Where(
          c => c.CartId == ShoppingCartId).ToList();
    }

    public decimal GetTotal()
    {
      ShoppingCartId = GetCartId();
      // Multiply product price by quantity of that product to get        
      // the current price for each of those products in the cart.  
      // Sum all product price totals to get the cart total.   
      decimal? total = decimal.Zero;
      total = (decimal?)(from cartItems in _db.ShoppingCartItems
                         where cartItems.CartId == ShoppingCartId
                         select (int?)cartItems.Quantity *
                         cartItems.Product.UnitPrice).Sum();
      return total ?? decimal.Zero;
    }

    public ShoppingCartActions GetCart(HttpContext context)
    {
      using (var cart = new ShoppingCartActions())
      {
        cart.ShoppingCartId = cart.GetCartId();
        return cart;
      }
    }

    public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
    {
      using (var db = new WingtipToys.Models.ProductContext())
      {
        try
        {
          int CartItemCount = CartItemUpdates.Count();
          List<CartItem> myCart = GetCartItems();
          foreach (var cartItem in myCart)
          {
            // Iterate through all rows within shopping cart list
            for (int i = 0; i < CartItemCount; i++)
            {
              if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
              {
                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                {
                  RemoveItem(cartId, cartItem.ProductId);
                }
                else
                {
                  UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity);
                }
              }
            }
          }
        }
        catch (Exception exp)
        {
          throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
        }
      }
    }

    public void RemoveItem(string removeCartID, int removeProductID)
    {
      using (var _db = new WingtipToys.Models.ProductContext())
      {
        try
        {
          var myItem = (from c in _db.ShoppingCartItems where c.CartId == removeCartID && c.Product.ProductID == removeProductID select c).FirstOrDefault();
          if (myItem != null)
          {
            // Remove Item.
            _db.ShoppingCartItems.Remove(myItem);
            _db.SaveChanges();
          }
        }
        catch (Exception exp)
        {
          throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
        }
      }
    }

    public void UpdateItem(string updateCartID, int updateProductID, int quantity)
    {
      using (var _db = new WingtipToys.Models.ProductContext())
      {
        try
        {
          var myItem = (from c in _db.ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductID == updateProductID select c).FirstOrDefault();
          if (myItem != null)
          {
            myItem.Quantity = quantity;
            _db.SaveChanges();
          }
        }
        catch (Exception exp)
        {
          throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
        }
      }
    }

    public void EmptyCart()
    {
      ShoppingCartId = GetCartId();
      var cartItems = _db.ShoppingCartItems.Where(
          c => c.CartId == ShoppingCartId);
      foreach (var cartItem in cartItems)
      {
        _db.ShoppingCartItems.Remove(cartItem);
      }
      // Save changes.             
      _db.SaveChanges();
    }

    public int GetCount()
    {
      ShoppingCartId = GetCartId();

      // Get the count of each item in the cart and sum them up          
      int? count = (from cartItems in _db.ShoppingCartItems
                    where cartItems.CartId == ShoppingCartId
                    select (int?)cartItems.Quantity).Sum();
      // Return 0 if all entries are null         
      return count ?? 0;
    }

    public struct ShoppingCartUpdates
    {
      public int ProductId;
      public int PurchaseQuantity;
      public bool RemoveItem;
    }

    public void MigrateCart(string cartId, string userName)
    {
      var shoppingCart = _db.ShoppingCartItems.Where(c => c.CartId == cartId);
      foreach (CartItem item in shoppingCart)
      {
        item.CartId = userName;
      }
      HttpContext.Current.Session[CartSessionKey] = userName;
      _db.SaveChanges();
    }
  }
}