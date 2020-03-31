using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_LogVote
    {
        public int id { get; set; }
        public int voteId { get; set; }
        public string userIp { get; set; }
        public string userMac { get; set; }
        public DateTime datetimevote { get; set; }

        public TB_LogVote(int id,int voteid,string userip,string usermac,DateTime datevote) {
            this.id = id;
            this.voteId = voteid;
            this.userIp = userip;
            this.userMac = usermac;
            this.datetimevote = datevote;
        }
    }
}
