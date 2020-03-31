using CVote_Bussiness.DB.ListEntities;
using CVote_DataAccess.Model;
using CVote_DataAccess.Utils;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVote_Presentation.Controllers.ApiCustomVote
{
    public class ApiGraphicController : Controller
    {
        // GET: ApiGraphic
        public ActionResult Index(string id)
        {
            if (id != null)
            {
               ViewBag.Report = Report(id);
            }

            return View();
        }



        [HttpGet]
        public JsonResult Report(string id) {
            string[] colors = new string[9];
            string[] graphic = new string[] { };
            string[] options = new string[9];

            int idf = int.Parse(id);
            ListVote lv = new ListVote();
            
            List<ResultOptions> lstro = lv.getOptions(DBConnect.open(), idf);
            

            int order = lv.getOrderQuestion(DBConnect.open(), idf);

            TB_Votation_Questions _Questions = new TB_Votation_Questions();
            _Questions.votationId = idf;
            _Questions.order = order;


            TB_Votation_Questions qRequest = lv.getquestions(DBConnect.open(), _Questions);
            List<TB_Vote> votes = lv.getListVote("max", idf, qRequest.id, DBConnect.open());

            List<TB_Votation_Questions_Answer> lstanswer = lv.getAnswer(DBConnect.open(), qRequest.id);

            graphic = new string[] { qRequest.question, lstro[0].graphic, lstro[0].height.ToString(), lstro[0].width.ToString(), lstro[0].imagefondo };
            /*
                        for (int i = 0; i < lstro.Count; i++)
                        {
                            colors[i] = lstro[i].color;
                            options[i] = lstro[i].option;
                        }
                        */
            for (int i = 0; i < lstanswer.Count; i++)
            {
                colors[i] = lstro[i].color;
                options[i] = lstanswer[i].answer;
            }
            ResultVote rv = lv.getVote(votes);
            ResultVote rv2 = new ResultVote();
            string[] value = GetCountOptions(rv, rv2);
            var Tablero = new[] { graphic, colors, options, value };

            return Json(Tablero,JsonRequestBehavior.AllowGet);
        }

        public string[] GetCountOptions(ResultVote resultVote, ResultVote cvppt)
        {
            string[] arrayInt = new string[9];

            if (cvppt.a > 0 || resultVote.a > 0)
            {
                arrayInt[0] = (resultVote.a + cvppt.a).ToString();
            }
            if (cvppt.b > 0 || resultVote.b > 0)
            {
                arrayInt[1] = (resultVote.b + cvppt.b).ToString();
            }
            if (cvppt.c > 0 || resultVote.c > 0)
            {
                arrayInt[2] = (resultVote.c + cvppt.c).ToString();
            }
            if (cvppt.d > 0 || resultVote.d > 0)
            {
                arrayInt[3] = (resultVote.d + cvppt.d).ToString();
            }
            if (cvppt.e > 0 || resultVote.e > 0)
            {
                arrayInt[4] = (resultVote.e + cvppt.e).ToString();
            }
            if (cvppt.f > 0 || resultVote.f > 0)
            {
                arrayInt[5] = (resultVote.f + cvppt.f).ToString();
            }
            if (cvppt.g > 0 || resultVote.g > 0)
            {
                arrayInt[6] = (resultVote.g + cvppt.g).ToString();
            }
            if (cvppt.h > 0 || resultVote.h > 0)
            {
                arrayInt[7] = (resultVote.h + cvppt.h).ToString();
            }
            if (cvppt.i > 0 || resultVote.i > 0)
            {
                arrayInt[8] = (resultVote.i + cvppt.i).ToString();
            }
            if (cvppt.j > 0 || resultVote.j > 0)
            {
                arrayInt[9] = (resultVote.j + cvppt.j).ToString();
            }
            return arrayInt;
        }

    }
}