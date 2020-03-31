

namespace CVote_DataAccess.Model
{
    public class TB_User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int typeUserid { get; set; }
        public string nameUser { get; set; }
        public string lastnameUser { get; set; }
        public string dni { get; set; }


        public TB_User(int id, string login, string password, int typeUserid, string nameuser, string lastname, string dni)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.typeUserid = typeUserid;
            this.nameUser = nameuser;
            this.lastnameUser = lastname;
            this.dni = dni;
        }
        public TB_User() {
            this.id = 0;
            this.login = "";
            this.password = "";
            this.typeUserid = 1;
            this.nameUser = "";
            this.lastnameUser = "";
            this.dni = "";
        }
        public int getId() {
            return id;
        }

        
        public int setVotationUserId() {
            TB_Votation _Votation = new TB_Votation();
           return _Votation.setUserId(this.id);
        }
    }
}
