using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CITA
    {
        public int ID_CITA { get; set; }
        public int ID_DOCTOR { get; set; }
        public int ID_PACIENTE { get; set; }
        public DateTime FECHA { get; set; }
        public string HORA { get; set; }
        public string ESTADO { get; set; }
        public string TIPO_TRANSACCION { get; set; }
    }
}
