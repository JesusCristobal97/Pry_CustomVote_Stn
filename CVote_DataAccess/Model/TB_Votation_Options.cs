using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Votation_Options
    {
        public int id { get; set; }
        public int votationId { get; set; }
        public string letter { get; set; }
        public string valueoption { get; set; }
        public string color { get; set; }

        public TB_Votation_Options(int id,int vid,string letter,string value,string color) {
            this.id = id;
            this.votationId = vid;
            this.letter = letter;
            this.valueoption = value;
            this.color = color;
        }

        public TB_Votation_Options() {
            this.id = 0;
            this.votationId = 0;
            this.letter = "";
            this.valueoption = "";
            this.color = "";
        }
    }
}
