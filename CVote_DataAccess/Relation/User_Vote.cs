using CVote_DataAccess.DB;
using CVote_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Relation
{
    public class User_Vote
    {
        public TB_User user { get; set;}
        
        public string votation { get; set; }
        
        DB_User du = new DB_User();
        DB_Votation dv = new DB_Votation();
        /*
        public TB_User Login(TB_User tbuser,OleDbConnection db) {
            user = du.Login(tbuser,db);    
            return user;
        }
        public string openVotation(TB_Votation tbvota, OleDbConnection db) {

            tbvota.userId = user.id;
            votation = dv.openVotation(tbvota,db);
            return votation;
        }

    */
    }
}
