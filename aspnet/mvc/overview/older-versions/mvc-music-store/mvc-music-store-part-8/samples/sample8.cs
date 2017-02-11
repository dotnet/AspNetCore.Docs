using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
 
namespace MvcMusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAlbum = storeDB.Albums
                .Single(album => album.AlbumId == id);
 
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            cart.AddToCart(addedAlbum);
 
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            // Get the name of the album to display confirmation
            string albumName = storeDB.Carts
                .Single(item => item.RecordId == id).Album.Title;
 
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
 
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}