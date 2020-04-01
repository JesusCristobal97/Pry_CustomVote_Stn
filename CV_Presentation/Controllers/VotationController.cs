using CVote_Bussiness.DB.Entities;
using CVote_DataAccess.DBList;
using CVote_DataAccess.Model;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVote_Presentation.Controllers
{
    public class VotationController : Controller
    {
        // GET: Votation
        public ActionResult cVotation()
        {
            if (Session["User"] != null)
            { return View(); }
            else {
                return RedirectToAction("Login","Home");
            }
                
        }
        public ActionResult cOptions()
        {
            if (Session["User"] != null)
            { return View(); }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult cQuestions()
        {
            if (Session["User"] != null)
            { return View(); }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult cGraphic()
        {
            if (Session["User"] != null)
            { return View(); }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult cVotants()
        {
            if (Session["User"] != null)
            { return View(); }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult StartVotation(string key)
        {
            if (Session["User"] != null)
            {

                if (key != null)
                {

                    TB_Votation_Data _DATA = new TB_Votation_Data();
                    TB_Votation v = new TB_Votation();
                    v.id = int.Parse(key);
                    v.status = 2;
                    _DATA.changeStatusVotation(DBConnect.open(), v);
                    TB_Votation_URL url = new TB_Votation_URL();

                    if (v.status == 2)
                    {
                        Guid keyg = Guid.NewGuid();
                        url.votationId = v.id;
                        url.keyVotation = keyg.ToString();
                        url.urlVotation = "";
                        var _URL = _DATA.createURLVotation(url, DBConnect.open());
                        ViewBag.URL = _URL.keyVotation;
                        ViewBag.UrlGrafico = key;
                    }
                    return View();
                }
                else {
                    return RedirectToAction("IndexVotation", "Home");
                }

            }
            else {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult VotantsLogin(string key) {


                DBVotationList votationList = new DBVotationList();
                int id = votationList.getIdURL(key, DBConnect.open());

                if (id > 0)
                {
                    ViewBag.Message = "1";
                }
                else
                {
                    ViewBag.Message = "0";
                }
                return View();
            

        }
    }
}