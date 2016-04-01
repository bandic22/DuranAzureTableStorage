using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DuranAssignmentBluePython.Services;
using DuranAssignmentBluePython.Models;

namespace DuranAssignmentBluePython.Controllers
{
    public class HomeController : Controller
    {
        private TableStorageService _service = new TableStorageService();

        public ActionResult Index()
        {
            var userEntities = _service.GetUsers();
            return View(userEntities);
        }

        public ActionResult Details(string name)
        {
            var userEntity = _service.GetUserDetails(name);
            return View(userEntity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserEntity userEntity)
        {
            _service.PostUser(userEntity);
            return RedirectToAction("Index");
        }
    }
}