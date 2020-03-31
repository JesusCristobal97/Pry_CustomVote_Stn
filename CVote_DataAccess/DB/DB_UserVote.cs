using CVote_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.DB
{
   public class DB_UserVote
    {
        public TB_UserVote Login(TB_UserVote userv, OleDbConnection db)
        {

            DataSet dataSet = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from TB_UserVote where Login='" + userv.login + "'and Password ='" + userv.password + "';", db); ;
            da.Fill(dataSet);
            db.Close();
            DataTable dt = dataSet.Tables[0];
            TB_UserVote _Userv = null;
            foreach (DataRow rows in dt.Rows)
            {
                _Userv = new TB_UserVote(
                    int.Parse(rows["Id"].ToString()),
                    rows["Login"].ToString(),
                    rows["Password"].ToString(),
                    int.Parse(rows["TypeUserId"].ToString()),
                    int.Parse(rows["VotationId"].ToString()),
                    rows["NameUser"].ToString(),
                    rows["LastNameUser"].ToString(),
                    rows["DocumentNumber"].ToString());
            }
            return _Userv;
        }
    }
}
