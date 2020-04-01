using CVote_Bussiness.DB.Entities;
using CVote_Bussiness.DB.ListEntities;
using CVote_DataAccess.Model;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace CVote_Presentation.Controllers.ApiCustomVote
{
    public class ApiVotationController : Controller
    {
        TB_Votation_Data TB_vota = new TB_Votation_Data();
        ListVotation listVotation = new ListVotation();
        TB_Votation tb_Votation = new TB_Votation();

        List<TB_Votation> lstVotation = new List<TB_Votation>();
        List<TB_Votation_Questions> lstQuestion = new List<TB_Votation_Questions>();
        List<TB_Votation_Questions_Answer> lstanswer = new List<TB_Votation_Questions_Answer>();
        List<TB_TypeGraphic> lsttypegraphic = new List<TB_TypeGraphic>();
        List<TB_UserVote> lstUserVote = new List<TB_UserVote>();

        // POST: ApiVotation
        [HttpPost]
        public JsonResult OpenVotation(TB_Votation votation)
        {
            //TB_User user = (TB_User) Session["User"];

            votation.userId = 1 /*user.id*/;
            tb_Votation = TB_vota.openVotation(votation, DBConnect.open());
            Session["Votation"] = tb_Votation;

            return Json(tb_Votation);
        }

        [HttpPost]
        public JsonResult CreateOptionvotation(TB_Votation_Options opt) 
        {
            string respuesta = TB_vota.addOptions(opt, DBConnect.open());
            return Json(respuesta);
        }

        [HttpPost]
        public ActionResult UploadFile() {
            
            int idVotation = int.Parse(Request.Form[0].ToString());
            string fullpath = "";
            if (Request.Files.Count > 0 && idVotation > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    //for (int i = 0; i < files.Count; i++)
                   // {
                        HttpPostedFileBase file = files[0];
                        string fname;
                    var req = Request.Browser.Browser.ToUpper();
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else 
                        {
                            //fname = file.FileName;
                            string filen = Request.Files.AllKeys[0].ToString();
                            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource\\Upload\\Question\\");
                            fullpath = Path.Combine(path, filen);
                            file.SaveAs(fullpath);
                        }
                        using (var reader = new StreamReader(fullpath, Encoding.Default, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(';');

                                if (!values[0].Contains("Orden"))
                                {
                                    TB_Votation_Questions questions = new TB_Votation_Questions();
                                    questions.order = int.Parse(values[0].ToString());
                                    questions.votationId = idVotation;
                                    questions.question = values[1].ToString();
                                    int idQuestion =  TB_vota.addQuestions(questions, DBConnect.open());

                                    TB_Votation_Questions_Answer answer = new TB_Votation_Questions_Answer();
                                    answer.questionId = idQuestion;
                                    for (int e = 2; e <= values.Length-1; e++)
                                    {
                                        if (values[e].ToString() != "") { 
                                            answer.answer = values[e].ToString();
                                            TB_vota.addAnswer(answer, DBConnect.open());
                                        }
                                    }
                                   
                                }
                            }
                        }
                    System.IO.File.Delete(fullpath);
                  

                    }
              //  }
                catch (System.Exception ex)
                {
                    return Json("Error is " +  ex.Message);
                }
                
                return Json("File Uploaded");
            }
            else {
                return Json("No files selected");
            }
        }

    

        [HttpPost]
        public ActionResult UploadImage() {

            string file = Request.Files.AllKeys[0].ToString();

            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFileBase fbase = Request.Files[0];
                    string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource\\");
                    string fullpath = Path.Combine(path, file);
                    if (fbase != null && fbase.ContentLength > 0)
                    {
                        fbase.SaveAs(fullpath);
                        TB_Votation_Graphic _Graphic = new TB_Votation_Graphic();
                        _Graphic.VotationId = int.Parse(Request.Form[0].ToString());
                        _Graphic.GraphicId = int.Parse(Request.Form[1].ToString());
                        _Graphic.ImageG = file;
                        _Graphic.width = int.Parse(Request.Form[2].ToString());
                        _Graphic.height = int.Parse(Request.Form[3].ToString());
                        TB_vota.addGraphic(_Graphic,DBConnect.open());
                        return Json("Gràfico insertado correctamente");

                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

            return Json("");
        }

        [HttpPost]
        public ActionResult UploadFileVotants()
        {
            if (Request.Files.Count > 0)
            {
                int idVotation = int.Parse(Request.Form[0].ToString());
                string fullpath = "";
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                        HttpPostedFileBase file = files[0];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            string filen = Request.Files.AllKeys[0].ToString();
                            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource\\Upload\\Users\\");
                            fullpath = Path.Combine(path, filen);
                            file.SaveAs(fullpath);
                        }
                        using (var reader = new StreamReader(fullpath, Encoding.Default, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(';');

                                if (!values[0].Contains("Name"))
                                {
                                    TB_UserVote userVote = new TB_UserVote();
                                    userVote.nameUser = values[0].ToString();
                                    userVote.lastnameUser = values[1].ToString();
                                    userVote.votationid = idVotation;
                                    userVote.typeUserid = 3;
                                    userVote.dni = values[2].ToString();
                                    userVote.login = values[3].ToString();
                                    userVote.password = values[4].ToString();
                                    TB_vota.addVotantes(userVote,DBConnect.open());
                                }
                            }
                        }
                    System.IO.File.Delete(fullpath);
                }
                catch (System.Exception ex)
                {

                    return Json("Error is " + ex.Message);
                }
            }

            return Json("");
        }

        [HttpPost]
        public JsonResult CreateUserVotation(TB_UserVote userVote)
        {
            string result = TB_vota.addVotantes(userVote, DBConnect.open());
           // Session["Votation"] = tb_Votation;
            return Json(result);
        }

        [HttpPost]
        public JsonResult StateVotationChange(TB_Votation v) {

            TB_vota.changeStatusVotation(DBConnect.open(), v);
            TB_Votation_URL url = new TB_Votation_URL();

            if (v.status == 2)
            {
                Guid key = Guid.NewGuid();
                url.votationId = v.id;
                url.keyVotation = key.ToString();
                url.urlVotation = "";
                TB_vota.createURLVotation(url, DBConnect.open());

            }
            return Json(url.keyVotation);

        }



        [HttpGet]
        public JsonResult VotationCreated() {
            lstVotation = listVotation.getVotesCreated(DBConnect.open());
            return Json(lstVotation, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult QuestionVotation(int id)
        {
            lstQuestion = listVotation.getQuestionVotation(DBConnect.open(), id);
            return Json(lstQuestion, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult QuestionAnswer(int id)
        {
            lstanswer = listVotation.getQuestionAnswer(DBConnect.open(), id);
            return Json(lstanswer, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TypeGraphic()
        {
            lsttypegraphic = listVotation.getTypeGraphic(DBConnect.open());
            return Json(lsttypegraphic, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult DownloadTemplate(string file)
        {
        
            string fullPath = Path.Combine(HostingEnvironment.MapPath(@"~/App_Data/template/"), file);
            return File(fullPath, "application/CSV", file);
        }



    }
}