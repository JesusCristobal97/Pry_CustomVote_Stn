using CVote_DataAccess.DBList;
using CVote_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_Bussiness.DB.ListEntities
{
   public class ListVotation
    {
        DBVotationList dBVotationList = new DBVotationList();
        public List<TB_Votation> getVotesCreated(OleDbConnection db)
        {
            return dBVotationList.getVotesCreated(db);
        }
        public List<TB_Votation_Questions> getQuestionVotation(OleDbConnection db,int idVotation) {
            return dBVotationList.getQuestionVotation(db, idVotation);
        }
        public List<TB_Votation_Questions_Answer> getQuestionAnswer(OleDbConnection db, int idQuestion)
        {
            return dBVotationList.getQuestionAnswer(db, idQuestion);
        }
        public List<TB_TypeGraphic> getTypeGraphic(OleDbConnection db)
        {
            return dBVotationList.getTypeGraphic(db);
        }
        public int getIdURL(string key, OleDbConnection db)
        {
            return dBVotationList.getIdURL(key,db);
        }

   }
}
