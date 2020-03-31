using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Votation_Questions_Answer
    {
        public int id { get; set; }
        public int questionId { get; set; }
        public string answer { get; set; }

        public TB_Votation_Questions_Answer(int id,int qid,string answer) {
            this.id = id;
            this.questionId = qid;
            this.answer = answer;
        }
        public TB_Votation_Questions_Answer() { 
        }
    }
}
