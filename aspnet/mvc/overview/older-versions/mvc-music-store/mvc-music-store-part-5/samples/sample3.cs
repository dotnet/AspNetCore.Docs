using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
 
namespace MvcMusicStore.Controllers
{ 
    public class StoreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();