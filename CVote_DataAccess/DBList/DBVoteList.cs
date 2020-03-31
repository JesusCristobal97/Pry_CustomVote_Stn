using CVote_DataAccess.Model;
using CVote_DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace CVote_DataAccess.DBList
{
    public class DBVoteList
    {
        public TB_Votation_Questions getquestions(OleDbConnection db, TB_Votation_Questions q)
        {
            DataSet ds = new DataSet();
            TB_Votation_Questions questions = new TB_Votation_Questions();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT TOP 1 ID,QUESTION FROM TB_VOTATION_QUESTIONS WHERE VOTATIONID =" + q.votationId + " AND [ORDER] =" + q.order, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    questions.id = int.Parse(rows["ID"].ToString());
                    questions.question = rows["question"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return questions;
        }
        public List<TB_Votation_Questions_Answer> getAnswer(OleDbConnection db, int Qid)
        {
            DataSet ds = new DataSet();
            List<TB_Votation_Questions_Answer> lstAnswer = new List<TB_Votation_Questions_Answer>();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT ANSWER FROM TB_VOTATION_QUESTIONS_answer WHERE QuestionId =" + Qid, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Votation_Questions_Answer answer = new TB_Votation_Questions_Answer();
                    answer.answer = rows["ANSWER"].ToString();
                    lstAnswer.Add(answer);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstAnswer;
        }


        public List<ResultOptions> getOptions(OleDbConnection db, int id) {
            DataSet ds = new DataSet();
            List<ResultOptions> lstresult = new List<ResultOptions>();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM (TB_VOTATION_OPTIONS O INNER JOIN TB_VOTATION_GRAPHIC G ON O.VOTATIONID = G.VOTATIONID) INNER JOIN TB_VOTATION V  ON V.ID = G.VOTATIONID WHERE V.ID =" + id, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    ResultOptions result = new ResultOptions();
                    result.title = rows["Title"].ToString();
                    result.option = rows["ValueOption"].ToString();
                    result.color = rows["Color"].ToString();
                    result.graphic = rows["GraphicId"].ToString();
                    result.imagefondo = rows["ImageG"].ToString();
                    result.height = int.Parse(rows["Heigth"].ToString());
                    result.width = int.Parse(rows["Width"].ToString());
                    lstresult.Add(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstresult;
        }
       
        public List<TB_Vote> ListVote(string type, int id,int qid, OleDbConnection db)
        {
            List<TB_Vote> votes = new List<TB_Vote>();
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tb_vote t1 where FHVote=(select " + type + "(FHVote) from tb_vote t2 where t1.MAC=t2.MAC and t2.Votationid  =" + id+ " and t2.QuestionId="+qid+")", db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Vote vote = new TB_Vote();
                    vote.id = int.Parse(rows["Id"].ToString());
                    vote.votationid = int.Parse(rows["votationid"].ToString());
                    vote.mac = rows["MAC"].ToString();
                    vote.userVoteid = int.Parse(rows["userVoteid"].ToString());
                    vote.result = rows["Result"].ToString();
                    vote.userVoteid = int.Parse(rows["userVoteid"].ToString());
                    vote.datevote = rows["FHVote"].ToString();
                    votes.Add(vote);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return votes;
        }

        public ResultVote getVote(List<TB_Vote> votes)
        {
            ResultVote rv = new ResultVote();

            var qx = from n in votes select n;

            rv.a = (from x in qx where x.result.Contains('1') select x).Count();
            rv.b = (from x in qx where x.result.Contains('2') select x).Count();
            rv.c = (from x in qx where x.result.Contains('3') select x).Count();
            rv.d = (from x in qx where x.result.Contains('4') select x).Count();
            rv.e = (from x in qx where x.result.Contains('5') select x).Count();
            rv.f = (from x in qx where x.result.Contains('6') select x).Count();
            rv.g = (from x in qx where x.result.Contains('7') select x).Count();
            rv.h = (from x in qx where x.result.Contains('8') select x).Count();
            rv.i = (from x in qx where x.result.Contains('9') select x).Count();
            rv.j = (from x in qx where x.result.Contains('0') select x).Count();


            return rv;
        }

        public int getOrderQuestion(OleDbConnection db, int VotationId)
        {
            DataSet ds = new DataSet();
            int order = 0;
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_VOTATION_URL WHERE VOTATIONID =" + VotationId , db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    order = int.Parse(rows["Order"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return order;
        }
        public int getQuestionId(OleDbConnection db, int VotationId)
        {
            DataSet ds = new DataSet();
            int order = 0;
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_VOTATION_URL WHERE VOTATIONID =" + VotationId, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    order = int.Parse(rows["QuestionId"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return order;
        }
    }
}
