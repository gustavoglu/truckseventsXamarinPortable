using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static async Task<object> GetLogin(Login login)
        {
            HttpClient client = new HttpClient();
            string loginSend = JsonConvert.SerializeObject(login);
            var content = new StringContent(loginSend, Encoding.UTF8, "application/json");
            try
            {
                var result = client.PostAsync(Constantes.WS_URILOGINTOKEN, content).Result;
                var contentResponse = await result.Content.ReadAsStringAsync();
                if (!result.IsSuccessStatusCode) return contentResponse;

                dynamic data = JObject.Parse(contentResponse);
                dynamic resultToken = data.data.result;


                Token token = JsonConvert.DeserializeObject<Token>(resultToken.ToString());
                if (token == null) return contentResponse;

                return token;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        public static async Task<object> Get<T>(string uri)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constantes.Token.access_token);

            try
            {
                var result = client.GetAsync(uri).Result;

                var obj = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode) return obj;

                var objDes = JsonConvert.DeserializeObject<T>(obj);

                return objDes;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<T> Post<T>(string uri, T obj) where T : class
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constantes.Token.access_token);

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
                string objDes = resultString;

                try
                {
                    objDes = JsonConvert.DeserializeObject<RestErrorMessage>(resultString).Message;
                }
                catch { }

                Utilidades.DialogErrorRestMessage(objDes);

                return null;
            }

        }

        public static async Task<T> Put<T>(string uri, T obj)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constantes.Token.access_token);
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
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constantes.Token.access_token);

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

            StringContent content = new StringContent(JsonConvert.SerializeObject(usuarioRegistroViewModel), Encoding.UTF8, "application/json");

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

