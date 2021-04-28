using AutoMapper;
using SeminarskiRSII.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class LoginService:ILoginService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public LoginService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Osoblje Authenticiraj(string username, string pass)
        {
            var user = _context.Osoblje.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = Util.PasswordGenerator.GenerateHash(pass, user.LozinkaSalt);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Osoblje>(user);
                }
            }
            return null;
        }

        public Model.Osoblje AuthenticirajGosta(string username, string pass)
        {
            var user = _context.Gost.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = Util.PasswordGenerator.GenerateHash(pass, user.LozinkaSalt);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Osoblje>(user);
                }
            }

            return null;
        }
    }
}
