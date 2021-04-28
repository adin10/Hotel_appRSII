using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRSII.Model
{
   public class GostiNotifikacije
    {
        public int Id { get; set; }
        public int NotifikacijaId { get; set; }
        public int gostID { get; set; }
        public bool Pregledana { get; set; }

        public virtual Notifikacije Notifikacija { get; set; }
        public virtual Gost Putnik { get; set; }
    }
}
