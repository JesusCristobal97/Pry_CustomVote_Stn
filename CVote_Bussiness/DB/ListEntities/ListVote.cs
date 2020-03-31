using CVote_DataAccess.DBList;
using CVote_DataAccess.Model;
using CVote_DataAccess.Utils;
using System.Collections.Generic;
using System.Data.OleDb;

namespace CVote_Bussiness.DB.ListEntities
{
    public class ListVote
    {
        DBVoteList dl = new DBVoteList();
        public TB_Votation_Questions getquestions(OleDbConnection db, TB_Votation_Questions q) {
            return dl.getquestions(db,q);
        }
        public List<TB_Votation_Questions_Answer> getAnswer(OleDbConnection db, int Qid)
        {
            return dl.getAnswer(db,Qid);
        }
        public List<TB_Vote> getListVote(string type, int id,int qid, OleDbConnection db)
        {
            return dl.ListVote(type,id,qid,db);
        }

        public ResultVote getVote(List<TB_Vote> votes) {
            return dl.getVote(votes);
        }
        public List<ResultOptions> getOptions(OleDbConnection db, int id) {
            return dl.getOptions(db,id);
        }
        public int getOrderQuestion(OleDbConnection db, int VotationId) {
            return dl.getOrderQuestion(db, VotationId);
        }
        public int getQuestionId(OleDbConnection db, int VotationId) {
            return dl.getQuestionId(db,VotationId);
        }
    }
}
