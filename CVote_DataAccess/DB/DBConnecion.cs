using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.DB
{
    public class DBConnecion
    {
        static OleDbConnection _OLCN = new OleDbConnection();

        public static string HostingEnviroment { get; set; }
        public static string _PATH { get; set; }

        public DBConnecion(string sHostingEnviroment)
        {
            HostingEnviroment = sHostingEnviroment;
            _PATH = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + HostingEnviroment + "'";
        }
        public static OleDbConnection Openconectio_One()
        {
            try
            {
                _OLCN = new OleDbConnection(_PATH);
                _OLCN.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return _OLCN;
        }

        public static OleDbConnection Openconection_Two()
        {
            try
            {
                _OLCN = new OleDbConnection(_PATH);
                _OLCN.Open();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return _OLCN;
        }
    }
}
