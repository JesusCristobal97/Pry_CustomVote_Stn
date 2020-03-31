using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using CVote_Bussiness.DB;
namespace CVote_Presentation.Models
{
    public class DBConnect
    {
        static string _PATH = HostingEnvironment.MapPath(@"~/App_Data/DBCustomVote.mdb");
        public static OleDbConnection  open() {
           return DBConnectData.getConnecion(_PATH);
        }
        public static OleDbConnection opentwo()
        {
            return DBConnectData.getConnecion2(_PATH);
        }
    }
}