using CVote_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.DB
{
     public class DB_Vote
    {
        public string insertVote(TB_Vote vote, OleDbConnection db)
        {
            string result = "";

            try
            {
                string sql = @"INSERT INTO TB_Vote(VotationId,MAC,UserVoteId,Result,QuestionId,FHVote) VALUES (" + vote.votationid + ",'"+vote.mac+"'," + vote.userVoteid + ",'" + vote.result + "',"+vote.questionid+",'" + vote.datevote +"')";
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
        public string deleteVoteforQuestion(TB_Vote vote, OleDbConnection db)
        {
            string result = "";

            try
            {
                string sql = @"DELETE FROM TB_Vote WHERE VotationId ="+vote.votationid+" AND QuestionId="+vote.questionid;
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN ELIMINADA";
            }
            catch (Exception)
            {

                throw;
            }


            return result;

        }

        public string deleteVote(TB_Vote vote, OleDbConnection db)
        {
            string result = "";

            try
            {
                string sql = @"DELETE FROM TB_Vote WHERE VotationId =" + vote.votationid;
                OleDbCommand cmd = new OleDbCommand(sql, db);
                cmd.ExecuteNonQuery();
                db.Close();
                result = "VOTACIÒN ELIMINADA";
            }
            catch (Exception)
            {

                throw;
            }
            return result;

        }


    }
}
