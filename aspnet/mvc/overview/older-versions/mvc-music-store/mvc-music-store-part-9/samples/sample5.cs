using System;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;
 
namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        const string PromoCode = "FREE";