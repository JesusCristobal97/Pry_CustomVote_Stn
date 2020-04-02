using CVote_DataAccess.Model;
using CVote_DataAccess.Utils;
using System.Data;
using System.Data.OleDb;

namespace CVote_DataAccess.DB
{
   public class DB_User
   {
        public TB_User Login(TB_User user,OleDbConnection db) {

            string pwd = Security.DesEncriptar(user.password);

            DataSet dataSet = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from TB_User where Login='" + user.login + "'and Password ='" + user.password + "';", db); ;
            da.Fill(dataSet);
            db.Close();
            DataTable dt = dataSet.Tables[0];
            TB_User _User = null;
            foreach (DataRow rows in dt.Rows)
            {
                _User = new TB_User(
                    int.Parse(rows["Id"].ToString()),
                    rows["Login"].ToString(),
                    rows["Password"].ToString(),
                    int.Parse(rows["TypeUserId"].ToString()),
                    rows["NameUser"].ToString(),
                    rows["Lastname"].ToString(),
                    rows["DNI"].ToString());
            }
            return _User;
        }
   }
}
