using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Votation_URL
    {
        public int id { get; set; }
        public int votationId { get; set; }
        public string keyVotation { get; set; }
        public string urlVotation { get; set; }

        public int order { get; set; }
        public int questionid { get; set; }


    }
}
