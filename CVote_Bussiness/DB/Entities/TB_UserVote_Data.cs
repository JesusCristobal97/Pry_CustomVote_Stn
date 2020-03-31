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
    public class TB_UserVote_Data
    {
        DB_UserVote userVote = new DB_UserVote(); 
        public TB_UserVote Login(TB_UserVote userv, OleDbConnection db) {
            return userVote.Login(userv, db);
        }
    }
}
