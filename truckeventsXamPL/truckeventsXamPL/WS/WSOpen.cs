using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;
using truckeventsXamPL.ViewModels;

namespace truckeventsXamPL.WS
{
    public class WSOpen
    {
        public static async Task<Token> GetLogin(Login login)
        {
            HttpClient client = new HttpClient();

            var send = string.Format("grant_type=password&username={0}&password={1}", login.UserName, login.Password);
            var content = new StringContent(send, Encoding.UTF8, "application/text");
            var result = client.PostAsync(Constantes.WS_URILOGINTOKEN, content).Result;

            if (result.IsSuccessStatusCode)
            {
                var contentToken = await result.Content.ReadAsStringAsync();
                Token token = JsonConvert.DeserializeObject<Token>(contentToken);

                if (token != null)
                {
                    return token;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static async Task<T> Get<T>(string uri)
        {
            HttpClient client = new HttpClient();

            var result = client.GetAsync(uri).Result;

            if (result.IsSuccessStatusCode)
            {
                var obj = await result.Content.ReadAsStringAsync();

                var objDes = JsonConvert.DeserializeObject<T>(obj);

                if (objDes != null)
                {
                    return objDes;
                }
                else
                {
                    return default(T);
                }
            }

            return default(T);

        }

        public static async Task<T> Post<T>(string uri, T obj)
        {
            HttpClient client = new HttpClient();

            var objSer = JsonConvert.SerializeObject(obj);

            StringContent content = new StringContent(objSer, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(uri, content);

            var resultString = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var objDes = JsonConvert.DeserializeObject<T>(resultString);

                return objDes;
            }
            else
            {
                return default(T);
            }

        }

        public static async Task<T> Put<T>(string uri, T obj)
        {
            HttpClient client = new HttpClient();

            var objSer = JsonConvert.SerializeObject(obj);

            StringContent content = new StringContent(objSer, Encoding.UTF8, "application/json");

            var result = await client.PutAsync(uri, content);

            var resultString = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var objDes = JsonConvert.DeserializeObject<T>(resultString);

                return objDes;
            }
            else
            {
                return default(T);
            }

        }

        public static async Task<T> Delete<T>(string uri, string id)
        {
            string uriDelete = uri + "/" + id;

            HttpClient client = new HttpClient();

            var result = await client.DeleteAsync(uriDelete);

            var resultString = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var objDes = JsonConvert.DeserializeObject<T>(resultString);

                return objDes;
            }
            else
            {
                return default(T);
            }

        }

        public static async Task<bool> PostRegistroUsuario(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            HttpClient client = new HttpClient();
            string uri = Constantes.WS_REGISTRO;
        
            StringContent content = new StringContent(JsonConvert.SerializeObject(usuarioRegistroViewModel),Encoding.UTF8,"application/json");

            var result = await client.PostAsync(uri, content);
            string resultString = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

