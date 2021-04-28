using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRSII.Model
{
   public class Novosti
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }

        public int? OsobljeId { get; set; }
        public Osoblje Osoblje { get; set; }
    }
}
