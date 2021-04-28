using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRSII.Model
{
    public class Drzava
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
