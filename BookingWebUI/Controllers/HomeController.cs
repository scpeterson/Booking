﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ploeh.Samples.Booking.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View();
        }
    }
}