
using System.Data.OleDb;
using CVote_DataAccess.DB;

namespace CVote_Bussiness.DB
{
   public class DBConnectData

    {
  
        public static OleDbConnection getConnecion(string _PATH)
        {
            DBConnecion db = new DBConnecion(_PATH);
            return DBConnecion.Openconectio_One();
        }

        public static OleDbConnection getConnecion2(string _PATH)
        {
            DBConnecion db = new DBConnecion(_PATH);
            return DBConnecion.Openconection_Two();
        }
    }
}
