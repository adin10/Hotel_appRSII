using Flurl.Http;
using SeminarskiRSII.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelRSII.Project
{
    public class ApiService
    {
        public static Gost gost { get; set; }
        public static string KorisnickoIme { get; set; }
        public static string Lozinka { get; set; }
        public static int GostId { get; set; }

        private string _route;
#if DEBUG
        private string _ApiUrl = "http://localhost:12848/api";

#endif

        public ApiService(string route)
        {
            _route = route;
        }
        public async Task<T> get<T>(object search)
        {

            var url = $"{ _ApiUrl}/{ _route}";
            try
            {
                if (search != null)
                {
                    url = url + "?";
                    url = url + await search.ToQueryString();
                }
                return await url.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani", "OK");
                }
                throw;
            }

        }
        public async Task<T> getByID<T>(object id)
        {
            var result = $"{_ApiUrl}/{_route}/{id}";
            return await result.WithBasicAuth(KorisnickoIme, Lozinka).GetJsonAsync<T>();

        }
        public async Task<T> Insert<T>(object request)
        {
            //var result = $"{Properties.Settings.Default.ApiUrl}/{_route}";
            //return await result.WithBasicAuth(KorisnickoIme, Lozinka).PostJsonAsync(search).ReceiveJson<T>();
            //var url = $"{_ApiUrl}/{_route}";
            //try
            //{
            //    return await url.WithBasicAuth(KorisnickoIme, Lozinka).PostJsonAsync(search).ReceiveJson<T>();
            //}
            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    if (errors == null)
            //    {
            //        throw;
            //    }
            //    else
            //    {
            //        var stringBuilder = new StringBuilder();
            //        foreach (var error in errors)
            //        {
            //            stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //        }

            //        await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
            //    }



            var url = $"{_ApiUrl}/{_route}";

            try
            {
                if (request is SeminarskiRSII.Model.Requests.GostiInsertRequest)
                    return await url.PostJsonAsync(request).ReceiveJson<T>();
                else
                    return await url.WithBasicAuth(KorisnickoIme, Lozinka).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new Exception(ex.Message);
            }


            //    return default(T);
        
        }
        //public async Task<T> Update<T>(object id, object request)
        //{
        //    var result = $"{_ApiUrl}/{_route}/{id}";
        //    return await result.WithBasicAuth(KorisnickoIme, Lozinka).PutJsonAsync(request).ReceiveJson<T>();
        //}
        public async Task<T> Update<T>(int id, object request)
        {
            var url = $"{_ApiUrl}/{_route}/{id}";

            try
            {
                return await url.WithBasicAuth(KorisnickoIme, Lozinka).PutJsonAsync(request).ReceiveJson<T>();
            }
            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
            //    return default(T);
            //}
            catch (FlurlHttpException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
