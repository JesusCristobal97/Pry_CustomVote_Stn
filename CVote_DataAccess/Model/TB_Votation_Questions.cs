using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
    public class TB_Votation_Questions
    {
        public int id { get; set; }
        public int votationId { get; set; }
        public int order { get; set; }
        public string question { get; set; }

        public TB_Votation_Questions(int id,int vid,int order,string question) {
            this.id = id;
            this.votationId = vid;
            this.order = order;
            this.question = question;
        }

        public TB_Votation_Questions() { 
        
        }
    }
}
