using System;
using System.Collections.Generic;
using System.Text;

namespace TT_App1_SL.Model
{
    public class Ciudadano
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellitoPat { get; set; }
        public String apellidoMat { get; set; }
        public DateTime fechaNac { get; set; }
        public String userName { get; set; }
        public String celular { get; set; }
        public String password { get; set; }
        public Boolean estado { get; set; }
    }
}
