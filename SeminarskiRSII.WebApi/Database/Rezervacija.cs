﻿using System;
using System.Collections.Generic;

namespace SeminarskiRSII.WebApi.Database
{
    public partial class Rezervacija
    {
        public int Id { get; set; }
        public int GostId { get; set; }
        public int SobaId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime ZavrsetakRezervacije { get; set; }
        public byte[] Qrcode { get; set; }
        public bool? Otkazana { get; set; }

        public virtual Gost Gost { get; set; }
        public virtual Soba Soba { get; set; }
    }
}
