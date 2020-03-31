using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVote_DataAccess.Model
{
    public class TB_TypeUser
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public TB_TypeUser(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

    }
}
