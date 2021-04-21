using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Student_Info.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Student_Info.Controllers
{
    public class StudentController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}   