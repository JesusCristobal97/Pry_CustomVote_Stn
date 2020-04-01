using CVote_DataAccess.DB;
using CVote_DataAccess.Model;
using CVote_DataAccess.Relation;
using System.Data.OleDb;

namespace CVote_Bussiness.DB.Entities
{
    public class TB_Votation_Data
    {
        DB_Votation _Votation = new DB_Votation();
        User_Vote user_Vote = new User_Vote();
        public TB_Votation openVotation(TB_Votation votation, OleDbConnection db) {
            return _Votation.openVotation(votation,db);
        }
        public string changeStatusVotation(OleDbConnection db, TB_Votation v)
        {
            return _Votation.changeStatusVotation(db,v);
        }
        public string addGraphic(TB_Votation_Graphic tvg,OleDbConnection db) {
            return _Votation.insertGraphic(tvg,db);
        }

        public string addOptions(TB_Votation_Options tvo, OleDbConnection db) {
            return _Votation.insertOptions(tvo, db);
        }

        public int addQuestions(TB_Votation_Questions tvq, OleDbConnection db) {
            return _Votation.insertQuestions(tvq,db);
        }

        public string addAnswer(TB_Votation_Questions_Answer tva, OleDbConnection db) {
            return _Votation.insertAnswer(tva,db);
        }
        public string addVotantes(TB_UserVote uv, OleDbConnection db){
            return _Votation.insertVotations(uv, db);
        }

        public TB_Votation_URL createURLVotation(TB_Votation_URL url, OleDbConnection db) {
            return _Votation.createURLVotation(url, db);
        }
        public string changeorderVotation(OleDbConnection db, TB_Votation_URL u) {
            return _Votation.changeorderVotation(db,u);
        }

        public string changeVisibleGraphic(OleDbConnection db, int votationid, bool visible) {
            return _Votation.changeVisibleGraphic(db,votationid,visible);
        }
        /*
        public TB_User Login(TB_User user, OleDbConnection db) {
            return user_Vote.Login(user,db);
        }

        public string openVote(TB_Votation votation, OleDbConnection db) {
            return user_Vote.openVotation(votation,db);
        }*/
    }
}
