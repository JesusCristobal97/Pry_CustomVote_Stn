using CVote_DataAccess.Model;
using CVote_DataAccess.Relation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.DBList
{
   public class DBVotationList
    {
        List<TB_Votation> lstVotation = new List<TB_Votation>();
        List<TB_Votation_Questions> lstquestion = new List<TB_Votation_Questions>();
        List<TB_Votation_Questions_Answer> lstanswer = new List<TB_Votation_Questions_Answer>();
        List<TB_TypeGraphic> lsttypegraphic = new List<TB_TypeGraphic>();
        Utils.Utils u = new Utils.Utils();
        
        /*LLENAR COMBO TRAER VOTACIONES CREADAS*/
        public List<TB_Votation> getVotesCreated(OleDbConnection db) {
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_Votation WHERE Status = 1", db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Votation _votation = new TB_Votation(
                        int.Parse(rows["Id"].ToString()),
                        rows["Users"].ToString(),
                        rows["Title"].ToString(),
                        int.Parse(rows["Status"].ToString()),
                        rows["Type"].ToString(),
                        Boolean.Parse(rows["Diapositive"].ToString()),
                        int.Parse(rows["NDiapositive"].ToString()),
                        int.Parse(rows["UserId"].ToString()));

                    lstVotation.Add(_votation);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstVotation;
        }
        public List<TB_Votation_Questions> getQuestionVotation(OleDbConnection db,int idVotation)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_Votation_Questions WHERE VotationId = "+ idVotation , db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Votation_Questions questions = new TB_Votation_Questions(
                        int.Parse(rows["Id"].ToString()),
                        int.Parse(rows["VotationId"].ToString()),
                        int.Parse(rows["Order"].ToString()),
                        rows["Question"].ToString());

                    lstquestion.Add(questions);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstquestion;
        }

        public List<TB_Votation_Questions_Answer> getQuestionAnswer(OleDbConnection db, int idQuestion)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_Votation_Questions_Answer WHERE QuestionId = " + idQuestion, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Votation_Questions_Answer answer = new TB_Votation_Questions_Answer(
                        int.Parse(rows["Id"].ToString()),
                        int.Parse(rows["QuestionId"].ToString()),
                        rows["Answer"].ToString());
                    lstanswer.Add(answer);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lstanswer;
        }

        public List<TB_TypeGraphic> getTypeGraphic(OleDbConnection db)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_TypeGraphic", db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_TypeGraphic typegraphic = new TB_TypeGraphic(
                        int.Parse(rows["Id"].ToString()),
                        rows["Descripcion"].ToString());
                    lsttypegraphic.Add(typegraphic);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lsttypegraphic;
        }

        public int getIdURL(string key,OleDbConnection db) {
            int id = 0;

            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT U.ID FROM TB_Votation_URL U inner join TB_VOTATION V ON U.VotationId = V.ID  WHERE  KeyVotation = '"+key+"' and V.STATUS = 2", db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {

                    id = int.Parse(rows["ID"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }


        public List<TB_Votation_Options> lstOptions(int id,OleDbConnection db)
        {
            List<TB_Votation_Options> lst = new List<TB_Votation_Options>();
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_VOTATION_OPTIONS WHERE VOTATIONID =" +id, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_Votation_Options vO = new TB_Votation_Options();
                    vO.id = int.Parse(rows["Id"].ToString());
                    vO.votationId = int.Parse(rows["VotationId"].ToString());
                    vO.letter = rows["Letter"].ToString();
                    vO.valueoption = rows["ValueOption"].ToString();
                    vO.color = rows["Color"].ToString();
                    lst.Add(vO);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lst;
        }
        public List<TB_UserVote> lstUserinVotation(int id, OleDbConnection db)
        {
            List<TB_UserVote> lst = new List<TB_UserVote>();
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM TB_USERVOTE WHERE VOTATIONID =" + id, db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    TB_UserVote uv = new TB_UserVote();
                    uv.id = int.Parse(rows["Id"].ToString());
                    uv.login = rows["Login"].ToString();
                    uv.votationid = int.Parse(rows["VotationId"].ToString());
                    uv.nameUser = rows["NameUser"].ToString();
                    uv.lastnameUser = rows["LastNameUser"].ToString();
                    uv.dni = rows["DocumentNumber"].ToString();

                    lst.Add(uv);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lst;
        }
        public List<VotationOQU> ReportIndex(OleDbConnection db,OleDbConnection db2, OleDbConnection db3) {
            List<VotationOQU> lst = new List<VotationOQU>();
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT V.ID,V.TITLE,TG.DESCRIPCION,V.STATUS,V.TYPE,Count(Q.Id) AS PREGUNTAS,V.USERS FROM ((TB_VOTATION V LEFT JOIN TB_VOTATION_GRAPHIC G ON G.VotationId = V.id) LEFT JOIN TB_VOTATION_QUESTIONS Q ON Q.VotationId = V.id) LEFT JOIN TB_TYPEGRAPHIC TG  ON TG.ID = G.ID  WHERE V.STATUS = 1 OR V.STATUS = 2  GROUP BY V.ID,V.TITLE,G.ID,V.STATUS,V.TYPE,V.USERS,TG.DESCRIPCION", db);
                da.Fill(ds);
                db.Close();
                DataTable dt = ds.Tables[0];
                foreach (DataRow rows in dt.Rows)
                {
                    VotationOQU oQU = new VotationOQU();
                    oQU.idVotation = int.Parse(rows["ID"].ToString());
                    oQU.title = rows["TITLE"].ToString();
                    oQU.graphic = rows["DESCRIPCION"].ToString();
                    oQU.status = u.getStatusV(rows["STATUS"].ToString());
                    oQU.type = u.getTypeV(rows["TYPE"].ToString());
                    oQU.questions = int.Parse(rows["PREGUNTAS"].ToString());
                    oQU.options = lstOptions(oQU.idVotation, db2).Count();
                    oQU.users = int.Parse(rows["USERS"].ToString());
                    oQU.usersregister = lstUserinVotation(oQU.idVotation, db3).Count();

                    lst.Add(oQU);
                }


            }
            catch (Exception)
            {
                VotationOQU oQU = new VotationOQU();
                lst.Add(oQU);
               
            }
            
            return lst;
        }
    
    
    }
}
