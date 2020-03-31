using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
   public class TB_Votation_Graphic
    {
        public int id { get; set; }
        public int VotationId { get; set; }
        public int GraphicId { get; set; }
        public string ImageG { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Boolean transparent { get; set; }


        public TB_Votation_Graphic(int id,int vid,int gid,string img,int width,int height,Boolean trans) {
            this.id = id;
            this.VotationId = vid;
            this.GraphicId = gid;
            this.ImageG = img;
            this.width = width;
            this.height = height;
            this.transparent = trans;
        }
        public TB_Votation_Graphic() { }
    }
}
