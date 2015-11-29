using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class MoviesAdminController : Controller
    {
        // GET: /Movies
        public ActionResult Index()
        {
            #region Index

            return View();

            #endregion
        }

        // GET: /Movies/Register
        public ActionResult Register()
        {
            #region Register

            return View();

            #endregion
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(long ID)
        {
            #region Edit

            return View(ID);

            #endregion
        }

        // GET: /Movies/Details/5
        public ActionResult Details(long ID)
        {
            #region Details

            return View(ID);

            #endregion
        }
    }
}