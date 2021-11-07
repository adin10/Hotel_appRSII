using AutoMapper;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.Osoblje, Model.Osoblje>().ReverseMap();
            CreateMap<OsobljeInsertRequest, Database.Osoblje>().ReverseMap();
            CreateMap<Database.Gost, Model.Osoblje>().ReverseMap();

            CreateMap<Database.VrstaOsoblja, Model.VrstaOsoblja>();
            CreateMap<Database.VrstaOsoblja, Model.VrstaOsoblja>().ReverseMap();

            CreateMap<VrstaOsobljaInsertRequest, Database.VrstaOsoblja>();

            CreateMap<Database.SobaStatus, Model.SobaStatus>();
            CreateMap<SobaStatusInsertRequest, Database.SobaStatus>();

            CreateMap<Database.Soba, Model.Soba>();
            CreateMap<SobaInsertRequest, Database.Soba>();

            CreateMap<Database.SobaOsoblje, Model.SobaOsoblje>();
            CreateMap<SobaOsobljeInsertRequest, Database.SobaOsoblje>();

            CreateMap<Database.Drzava, Model.Drzava>();
            CreateMap<DrzavaSearchRequest, Database.Drzava>();

            CreateMap<Database.Grad, Model.Grad>();
            CreateMap<GradInsertRequest, Database.Grad>();

            CreateMap<Database.OsobljeUloge, Model.OsobljeUloge>().ReverseMap();


            CreateMap<Database.Gost, Model.Gost>().ReverseMap();
            CreateMap<GostiInsertRequest, Database.Gost>();

            CreateMap<Database.Cjenovnik, Model.Cjenovnik>();
            CreateMap<CijenaInsertRequest, Database.Cjenovnik>();

            CreateMap<Database.Rezervacija, Model.Rezervacija>();
            CreateMap<RezervacijaInsertRequest, Database.Rezervacija>();

            CreateMap<Database.Recenzija, Model.Recenzija>();
            CreateMap<RecenzijaInsertRequest, Database.Recenzija>();


            //CreateMap<Database.Notifikacije, Model.Notifikacije>();
            //CreateMap<NotifikacijeInsertRequest, Database.Notifikacije>();
            CreateMap<Database.Notifikacije, Model.Notifikacije>();
            CreateMap<NotifikacijeInsertRequest, Database.Notifikacije>();


            //CreateMap<Database.Novosti, Model.Novosti>();
            //CreateMap<NovostiInsertRequest, Database.Novosti>();
            CreateMap<Database.Novosti, Model.Novosti>();
            CreateMap<NovostiInsertRequest, Database.Novosti>();


            //CreateMap<Database.GostiNotifikacije, Model.GostiNotifikacije>();
            CreateMap<Database.GostiNotifikacije, Model.GostiNotifikacije>();
            CreateMap<GostiNotifikacijeInsertRequest, Database.GostiNotifikacije>();


        }
    }
}
