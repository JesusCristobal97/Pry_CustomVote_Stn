using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Vote
    {
        public int id { get; set; }
        public int votationid { get; set; }
        public string mac { get; set; }
        public int userVoteid { get; set; }
        public string result { get; set; }
        public int questionid { get; set; }
        public string datevote { get; set; }

        public TB_Vote(int id,int vid,string mac,int usid,string result,int questionid, string dvote) {
            this.id = id;
            this.votationid = vid;
            this.mac = mac;
            this.userVoteid = usid;
            this.result = result;
            this.questionid = questionid;
            this.datevote = dvote;
        }
        public TB_Vote() { }
    }
}
