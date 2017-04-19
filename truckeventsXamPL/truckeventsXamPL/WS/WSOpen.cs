using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using truckeventsXamPL.Models;
using truckeventsXamPL.Util;

namespace truckeventsXamPL.WS
{
    public class WSOpen
    {
        public static async Task<Token> GetLogin(Login login)
        {
            HttpClient client = new HttpClient();

            var send = string.Format("grant_type=password&username={0}&password={1}", login.UserName, login.Password);
            var content = new StringContent(send, Encoding.UTF8, "application/text");
            var result = client.PostAsync(Constantes.WS_UriLoginToken, content).Result;

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
    }
}

