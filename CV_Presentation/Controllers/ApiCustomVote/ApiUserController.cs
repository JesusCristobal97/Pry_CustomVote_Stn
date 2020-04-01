
using System.Web.Mvc;
using CVote_Bussiness.DB;
using CVote_Bussiness.DB.Entities;
using CVote_DataAccess.Model;
using CVote_Presentation.Models;

namespace CVote_Presentation.Controllers.ApiCustomVote
{
    public class ApiUserController : Controller
    {
        TB_User_Data tu = new TB_User_Data();
        // POST: ApiUser

        [HttpPost]
        public JsonResult Login(TB_User user)
        {
            string MessageLogin = "";
            TB_User tbu = tu.login(user, DBConnect.open());
            if (tbu.id != 0)
            {
                Session["User"] = tbu;
                MessageLogin = "Usuario Validado";
            }
            else {
                MessageLogin = "Compruebe sus credenciales o comuniquese con el administrador";
            }
            return Json(MessageLogin, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOut()
        {
            if (Session["User"]!=null)
            {
                Session["User"] = null;

                return RedirectToAction("Login", "Home");
            }
            else{
                return View();
            }

        }
    }
}