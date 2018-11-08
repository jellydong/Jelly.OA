using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jelly.OA.BLL;
using Jelly.OA.Model;

namespace Jelly.OA.Portal.Controllers
{
    public class UserInfoController : Controller
    { 
        public UserInfoService userInfoService { get; set; }
        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = userInfoService.GetEntities(u => true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            userInfoService.Add(userInfo);
            return RedirectToAction("Index");
        }
    }
}