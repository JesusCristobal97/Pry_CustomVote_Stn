using CVote_DataAccess.DB;
using CVote_DataAccess.Model;
using System.Data.OleDb;

namespace CVote_Bussiness.DB.Entities
{
   public class TB_User_Data
    {
        DB_User _User = new DB_User();
        public TB_User login(TB_User user,OleDbConnection db)
        {
            return _User.Login(user,db);
        }
    }
}
