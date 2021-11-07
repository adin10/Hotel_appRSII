using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRSII.Project.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Drzave,
        Sobe,
        Novosti,
        Cjenovnik,
        Notifikacije,
        MojeRezervacije,
        Recenzija,
        ProfilPodaci,
        OdjaviSe
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
