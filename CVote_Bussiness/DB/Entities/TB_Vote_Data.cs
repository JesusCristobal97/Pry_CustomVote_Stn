using CVote_DataAccess.DB;
using CVote_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_Bussiness.DB.Entities
{
   public class TB_Vote_Data
    {
        DB_Vote _VOTE = new DB_Vote();

        public string addVote(TB_Vote vote,OleDbConnection db) {
            return _VOTE.insertVote(vote,db);
        }
        public string deleteVoteforQuestion(TB_Vote vote, OleDbConnection db) {
            return _VOTE.deleteVoteforQuestion(vote,db);
        }
        public string deleteVote(TB_Vote vote, OleDbConnection db) {
            return _VOTE.deleteVote(vote,db);
        }
        public string stopVote(int id, OleDbConnection db)
        {
            return _VOTE.stopVote(id,db);
        }
   }
}
