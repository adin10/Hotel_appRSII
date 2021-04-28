using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRSII.Model.Requests
{
   public  class RecenzijaInsertRequest
    {
        public int gostID { get; set; }
        public int sobaID { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
