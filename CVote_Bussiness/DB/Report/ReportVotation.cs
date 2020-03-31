using CVote_DataAccess.DBList;
using CVote_DataAccess.Relation;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_Bussiness.DB.Report
{
    public class ReportVotation
    {
        DBVotationList votationList = new DBVotationList();
        
        public List<VotationOQU> ReportIndex(OleDbConnection db, OleDbConnection db2, OleDbConnection db3) {
            return votationList.ReportIndex(db,db2,db3);
        }
    }
}
