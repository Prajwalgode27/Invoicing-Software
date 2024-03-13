using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShubhKarya.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult StoryIndex()
        {
            return View();
        }
        public ActionResult StoryDetails()
        {
            return View();
        }

    }
}