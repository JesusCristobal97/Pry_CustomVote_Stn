using CVote_Bussiness.DB.Entities;
using CVote_Bussiness.DB.ListEntities;
using CVote_Bussiness.DB.Report;
using CVote_DataAccess.Model;
using CVote_DataAccess.Relation;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login() {

            return View();
        }
        public ActionResult IndexVotation() {
            if (Session["User"] != null)
            {
                ReportVotation rv = new ReportVotation();
                List<VotationOQU> lstVotation = rv.ReportIndex(DBConnect.open(), DBConnect.open(), DBConnect.open());
                return View(lstVotation);
            }
            else {
                return RedirectToAction("Login");
            }
        }
    }
}