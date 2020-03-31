using CVote_DataAccess.Model;
using System;
using System.Data.OleDb;

namespace CVote_DataAccess.DB
{
    public class DB_Votation
    {
        public TB_Votation openVotation(TB_Votation v,OleDbConnection db) {
            string result = "";
            TB_Votation _Votation;
            try
            {
                string sql = @"INSERT INTO TB_Votation(Users,Title,Status,Type,Diapositive,NDiapositive,UserId) VALUES ("+ v.users   + ",'" + v.title + "'," + v.status + ",'" + v.type + "'," + v.diapositive + "," + v.ndiapositive + "," + v.userId + ")";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN INICIADA";
                _Votation = new TB_Votation(v.id,v.users,v.title,v.status,v.type,v.diapositive,v.ndiapositive,v.userId);
            }
            catch (Exception e)
            {
                result = e.Message;
                db.Close();
                throw;
            }
            return _Votation;
        }

        public string changeStatusVotation(OleDbConnection db, TB_Votation v) {
            string result = "";
            try
            {
                String sql = @"UPDATE TB_Votation SET Status =" +v.status + " WHERE Id = "+v.id;
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN ACTUALIZADA ";
            }
            catch (Exception e)
            {
                result = e.Message;
                db.Close();
                throw;
            }
            return result;
        }

        public TB_Votation_URL createURLVotation(TB_Votation_URL url, OleDbConnection db)
        {
            string result = "";
            TB_Votation_URL urltb = new TB_Votation_URL();
            try
            {
                string ifexist = @"select * from TB_Votation_URL where VotationId = " +url.votationId;
                OleDbCommand cmdexist = new OleDbCommand(ifexist, db);
                OleDbDataReader dr = cmdexist.ExecuteReader();

                if (!dr.Read())
                {
                    string sql = @"INSERT INTO TB_Votation_URL(VotationId,KeyVotation,URLVotation) VALUES (" + url.votationId + ",'" + url.keyVotation + "','" + url.urlVotation + "')";
                    OleDbCommand cmd = new OleDbCommand(sql, db);
                    cmd.ExecuteNonQuery();
                    result = "VOTACIÒN INICIADA";
                    urltb = url;
                }
                else {
                    urltb.keyVotation = dr.GetString(2); 
                }
                db.Close();

            }
            catch (Exception e)
            {
                result = e.Message;
                db.Close();
                throw;
            }
            return urltb;
        }

        #region graphic - options

        public string insertGraphic(TB_Votation_Graphic tvg,OleDbConnection db ) {
            string result = "";

            try
            {
                string sql = @"INSERT INTO TB_Votation_Graphic(VotationId,GraphicId,ImageG,Width,Heigth,Transparent) VALUES (" + tvg.VotationId + "," + tvg.GraphicId + ",'"+ tvg.ImageG +"'," + tvg.width + "," + tvg.height + "," + tvg.transparent +  ")";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN INICIADA";
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }

        public string insertOptions(TB_Votation_Options tvo,OleDbConnection db) {

            string result = "";

            try
            {
                string sql = @"INSERT INTO TB_Votation_Options(VotationId,Letter,ValueOption,Color) VALUES (" + tvo.votationId+ ",'" + tvo.letter + "','" + tvo.valueoption + "','" + tvo.color + "')";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN INICIADA";
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }

        public int insertQuestions(TB_Votation_Questions tvq, OleDbConnection db)
        {

            int result = 0;

            try
            {
                string sql = @"INSERT INTO TB_Votation_Questions(VotationId,[Order],Question) VALUES (" + tvq.votationId + "," + tvq.order + ",'" + tvq.question + "')";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                result = (int)cmd.ExecuteScalar();
                db.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }

        public string insertAnswer(TB_Votation_Questions_Answer tva, OleDbConnection db)
        {

            string result = "";

            try
            {
                string sql = @"INSERT INTO TB_Votation_Questions_Answer(QuestionId,Answer) VALUES (" + tva.questionId + ",'" + tva.answer + "')";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN INICIADA";
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }

        public string insertVotations(TB_UserVote uv, OleDbConnection db)
        {

            string result = "";

            try
            {
                string sql = @"INSERT INTO TB_UserVote(Login,[Password],TypeUserId,Votationid,NameUser,LastNameUser,DocumentNumber) VALUES ('" + uv.login + "','" + uv.password + "',"+uv.typeUserid +","+uv.votationid+",'"+uv.nameUser+"','"+uv.lastnameUser+"','"+uv.dni+"')";
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN INICIADA";
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }


        #endregion

        public string changeorderVotation(OleDbConnection db, TB_Votation_URL u)
        {
            string result = "";
            try
            {
                String sql = @"UPDATE TB_Votation_URL SET [Order] =" + u.order + ",QuestionId="+u.questionid +" WHERE VotationId = " + u.votationId;
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN URL ACTUALIZADA ";
            }
            catch (Exception e)
            {
                result = e.Message;
                db.Close();
                throw;
            }
            return result;
        }

    }
}
