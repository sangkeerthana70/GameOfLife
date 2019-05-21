using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOfLifeWebApplication.Models;

namespace GameOfLifeWebApplication.Controllers
{
    public class GridController : Controller
    {
        // GET: Grid
        public ActionResult Index()
        {
            Grid grid = new Grid(50, 50);
            return View(grid);
        }

    }
}
