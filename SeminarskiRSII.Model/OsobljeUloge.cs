using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRSII.Model
{
   public class OsobljeUloge
    {
        public int OsobljeUlogeId { get; set; }
        public int osobljeID { get; set; }
        public Osoblje osoblje { get; set; }
        public int vrstaOsobljaID { get; set; }
        public VrstaOsoblja vrstaOsoblja { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
