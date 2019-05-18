
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using System.Net.Http.Headers;
using Microsoft.CSharp;

namespace TT_App1_SL.Service
{
    class AuthService
    {

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://tt-izdcdmx.herokuapp.com/oauth/token");

            request.Content = new FormUrlEncodedContent(keyValues);
            string s = "angularjwtclientid" + ":" + "12345";
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(s);
            var credenciales = Convert.ToBase64String(byt);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic "+ credenciales);
            Debug.WriteLine(client);
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");
            return accessToken;
        }

        public async Task<String> RegistrarAsync(string nombre, string apellitoPat, string apellidoMat, DateTime fechaNac, string userName, string password, string celular)
        {
            var client = new HttpClient();
            var model = new Ciudadano
            {
                nombre = nombre,
                password = password,
                apellitoPat = apellitoPat,
                apellidoMat = apellidoMat,
                fechaNac = fechaNac,
                userName = userName,
                celular = celular,
                estado = true
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = null;
            response = await client.PostAsync("https://tt-izdcdmx.herokuapp.com/api/v1/ciudadano", content);
            Debug.WriteLine("Respuesta post " + response);
            if (!response.IsSuccessStatusCode)
            {
                var jwt = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Respuesta post " + jwt);
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
                var error = jwtDynamic.Value<string>("error");
                Debug.WriteLine("Respuesta post " + error);
                if(error.Contains("already exists"))
                {
                    if (error.Contains("celular"))
                    {
                        return "Celular";
                    }
                    else
                    {
                        return "Usuario";
                    }
                }
                else
                {
                    return "Otro";
                }
            }
           else
             {
                 return "Ok";
             }
        }

        public async Task SuspenderCuenta(string userName, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.DeleteAsync("https://tt-izdcdmx.herokuapp.com/api/v1/ciudadano/" + userName);
        }

        public async Task<CConfianza> GetContactoConfianza(string username, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync("https://tt-izdcdmx.herokuapp.com/api/v1/cconfianza/"+username);

            var contacto =  JsonConvert.DeserializeObject<CConfianza>(json);

            Debug.WriteLine("Contacto" + contacto);
            return contacto;
        }

        public async Task<Ciudadano> GetCiudadano(string accessToken, string userName)
        {

            var uri = new Uri("https://tt-izdcdmx.herokuapp.com/api/v1/ciudadano/"+userName);
            var _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            var response = await _client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            var ciudadano = JsonConvert.DeserializeObject<Ciudadano>(content);
            return ciudadano;
        }

        public async Task PostCConfianza (CConfianza contacto, string username,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
           
            var json = JsonConvert.SerializeObject(contacto);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("https://tt-izdcdmx.herokuapp.com/api/v1/cconfianza/"+ username, content);
            Debug.WriteLine("Respuesta post " + response);
        }

        public async Task PutCConfianza(CConfianza contacto, string accessToken, string username)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(contacto);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync("https://tt-izdcdmx.herokuapp.com/api/v1/cconfianza/" + username, content);

        }

        public async Task<string> Cercania(string distancia, string ubicacion, string username, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("distancia", distancia),
                new KeyValuePair<string, string>("ubicacion", ubicacion)
            };

           // var request = new HttpRequestMessage(HttpMethod.Get, "https://tt-izdcdmx.herokuapp.com/api/v1/ciudadano/cercania");

           // var request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.GetAsync("https://tt-izdcdmx.herokuapp.com/api/v1/ciudadano/cercania"+ "?distancia="+distancia+"&ubicacion="+ubicacion);
                                                  
            var cercano = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("response" + cercano);

            return cercano;
           
        }
    }
}
