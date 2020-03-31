using CVote_Bussiness.DB.Entities;
using CVote_DataAccess.Model;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVote_Presentation.Controllers.ApiCustomVote
{
    public class ApiUserVoteController : Controller
    {
        TB_UserVote_Data tu = new TB_UserVote_Data();
        // GET: ApiUserVote
        [HttpPost]
        public JsonResult Login(TB_UserVote userv)
        {
            string MessageLogin = "";
            TB_UserVote tbu = tu.Login(userv, DBConnect.open());
            if (tbu.id != null)
            {
                Session["UserVote"] = tbu;
                MessageLogin = "Usuario Validado";
            }
            else
            {
                MessageLogin = "Compruebe sus credenciales o comuniquese con el administrador";
            }
            return Json(MessageLogin, JsonRequestBehavior.AllowGet);
        }
    }
}