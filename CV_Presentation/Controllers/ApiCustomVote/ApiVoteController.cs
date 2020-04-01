using CVote_Bussiness.DB.Entities;
using CVote_Bussiness.DB.ListEntities;
using CVote_DataAccess.Model;
using CVote_DataAccess.Utils;
using CVote_Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace CVote_Presentation.Controllers.ApiCustomVote
{
    public class ApiVoteController : Controller
    {
        TB_Votation_Data _Data = new TB_Votation_Data();
        TB_Vote_Data _Vote = new TB_Vote_Data();

        ListVote lv = new ListVote();
        // GET: ApiVote
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public JsonResult getQuestions() {
            var userVote = (TB_UserVote)Session["UserVote"];

            ListVote lv = new ListVote();
            List<string> lsresult = new List<string>();

            int order = lv.getOrderQuestion(DBConnect.open(), userVote.votationid);

            TB_Votation_Questions _Questions = new TB_Votation_Questions();
            _Questions.votationId = userVote.votationid;
            _Questions.order = order;


            TB_Votation_Questions qRequest = lv.getquestions(DBConnect.open(), _Questions);
            List<TB_Votation_Questions_Answer> lstanswer = lv.getAnswer(DBConnect.opentwo(), qRequest.id);

            lsresult.Add(qRequest.question);

            for (int e = 0; e < lstanswer.Count; e++)
            {
                lsresult.Add(lstanswer[e].answer.ToString());
            }

            return Json(lsresult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult nextQuestion(int i, int type, int id) {
            int ix = 0;

            if (Session["nextQ"] != null)
            {
                ix = (int)Session["nextQ"];
                int x = 0;
                if (type == 1)
                {
                    x = ix += i;
                }
                else if (type == 2)
                {
                    x = ix -= i;
                }
                else if (type == 0) {
                    x = 1;
                }
                Session["nextQ"] = x;
            }
            else {
                Session["nextQ"] = i;
                ix = 1;
            }
            List<string> lsresult = new List<string>();

            TB_Votation_Questions _Questions = new TB_Votation_Questions();
            _Questions.votationId = id;
            _Questions.order = ix;

            TB_Votation_Questions qRequest = lv.getquestions(DBConnect.open(), _Questions);
            List<TB_Votation_Questions_Answer> lstanswer = lv.getAnswer(DBConnect.open(), qRequest.id);

            lsresult.Add(qRequest.question);

            for (int e = 0; e < lstanswer.Count; e++)
            {
                lsresult.Add(lstanswer[e].answer.ToString());
            }
            Session["votationid"]= id;
            Session["order"] = ix;
            Session["questionid"] = qRequest.id;


            return Json(lsresult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SelectQuestionforVotation() {
            TB_Votation_URL _URL = new TB_Votation_URL();
            _URL.votationId = int.Parse(Session["votationid"].ToString());
            _URL.order = int.Parse(Session["order"].ToString());
            _URL.questionid = int.Parse(Session["questionid"].ToString());
            _Data.changeorderVotation(DBConnect.open(), _URL);
            return Json("Votaciòn Iniciada , pregunta Nª" +_URL.order,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateVote(TB_Vote v) {
            var user = (TB_UserVote)Session["UserVote"];

            int order = lv.getOrderQuestion(DBConnect.open(), user.votationid);

            TB_Votation_Questions _Questions = new TB_Votation_Questions();
            _Questions.votationId = user.votationid;
            _Questions.order = order;


            TB_Votation_Questions qRequest = lv.getquestions(DBConnect.open(), _Questions);

            Utils u = new Utils();
            v.userVoteid = user.id;
            v.votationid = user.votationid;
            v.mac = getipUser();
            v.questionid = qRequest.id;
            TB_Vote_Data vdata = new TB_Vote_Data();
            string result = vdata.addVote(v,DBConnect.open());
            return Json(result);
        }


        [HttpGet]
        public JsonResult DeleteQuestion() {
            TB_Vote vote = new TB_Vote();
            vote.votationid = int.Parse(Session["votationid"].ToString()); 
            vote.questionid = int.Parse(Session["questionid"].ToString());
            _Vote.deleteVoteforQuestion(vote,DBConnect.open());
            return Json("");
        }

        [HttpGet]
        public JsonResult DeleteAllQuestion()
        {
            TB_Vote vote = new TB_Vote();
            vote.votationid = int.Parse(Session["votationid"].ToString());
            _Vote.deleteVote(vote, DBConnect.open());
            return Json("");
        }

        [HttpGet]
        public JsonResult StopVotación()
        {
            int id = int.Parse(Session["votationid"].ToString());
            var request = _Vote.stopVote(id, DBConnect.open());
            return Json(request,JsonRequestBehavior.AllowGet);
        }

        public string getipUser()
        {
            return Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
    }
}