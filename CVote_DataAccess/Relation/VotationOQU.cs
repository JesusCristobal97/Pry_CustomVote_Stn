using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Relation
{
    public class VotationOQU
    {
        public int idVotation { get; set; }
        public string title { get; set; }
        public string graphic { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int options { get; set; }
        public int questions { get; set; }
        public int users { get; set; }
        public int usersregister { get; set; }
    }
}
