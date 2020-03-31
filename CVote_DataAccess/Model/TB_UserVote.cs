using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_UserVote
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int typeUserid { get; set; }
        public int votationid { get; set; }
        public string nameUser { get; set; }
        public string lastnameUser { get; set; }
        public string dni { get; set; }


        public TB_UserVote(int id, string login, string password, int typeUserid,int votationid, string nameuser, string lastname, string dni)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.typeUserid = typeUserid;
            this.votationid = votationid;
            this.nameUser = nameuser;
            this.lastnameUser = lastname;
            this.dni = dni;
        }

        public TB_UserVote() { }
    }
}
