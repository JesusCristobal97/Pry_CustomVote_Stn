using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Votation
    {
        public int id { get; set; }
        public string users { get; set; } 
        public string title { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public Boolean diapositive { get; set; }
        public int ndiapositive { get; set; }
        public int userId { get; set; }


        public TB_Votation(int id,string users,string title, int status,string type,Boolean diapositive,int ndiapositive,int userid) {
            this.id = id;
            this.users = users;
            this.status = status;
            this.title = title;
            this.type = type;
            this.diapositive = diapositive;
            this.ndiapositive = ndiapositive;
            this.userId = userId;
        }

        public TB_Votation() {
            userId = 0;
        }

        public int getVotationId() {
            return this.id;
        }
        public int setUserId(int userid)
        {
            return this.userId = userId;
        }
    }
}
