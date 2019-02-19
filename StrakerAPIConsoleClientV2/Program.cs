using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script;
using System.Web.Script.Serialization;

namespace StrakerAPIConsoleClientV2
{
    class Program
    {
        // JSON C# clasess represetnation

        public class Language
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class RootObject
        {
            public List<Language> languages { get; set; }
        }
        // Para el post
        public class datos
        {
            public string title { get; set; }
            public string sl { get; set; }
            public string tl { get; set; }
            public string source_file { get; set; }
            public string token { get; set; }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Tests");
            GetLanguageList();
            Console.ReadLine();
        }
        static void GetLanguageList()
        {

            // { "source_file", "<?xml version='1.0' encoding='utf-8'?><root><data name='unique_identifier'><value>Welcome to the Straker Translations API</value></data></root>" },

            var content = new MultipartFormDataContent();
            var values = new Dictionary<string, string>
            {
                { "title", "hello" },
                { "sl", "English" },
                { "tl", "Spanish" },
                { "source_file", "This is a text" }
            };
            foreach (var keyValuePair in values)
            {
                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
            }


            HttpClient client2 = new HttpClient();
            // client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "9E839CBE-E581-4BB6-B5B792BF0E1C15B3") ;
            client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + "9E839CBE-E581-4BB6-B5B792BF0E1C15B3");
            // https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient
            client2.BaseAddress = new Uri("https://sandbox.strakertranslations.com:443/");
            var response2 = client2.PostAsync("v3/translate/file", content).Result;
            var responseString = response2.Content.ReadAsStringAsync().Result;
            RootObject rootdata = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.strakertranslations.com:443/");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("v3/languages").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            // la forma síncrona (que hay que encapular en una "static async Task<xxx> Nombre(); es
            // HttpResponseMessage response = await client.GetAsync(path);
               //use JavaScriptSerializer from System.Web.Script.Serialization
               JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                // dentro de tarea síncrona string data = await response.Content.ReadAsStringAsync();
                string data = response.Content.ReadAsStringAsync().Result; // sin asycn y con Result;
                rootdata= JSserializer.Deserialize<RootObject>(data);
                foreach (var d in rootdata.languages)
                {
                    Console.WriteLine("{0}", d.name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.
            // Lets try post
            datos p = new datos
            {
                title = "hello",
                sl = "English",
                tl = "Spanish",
                source_file = "<?xml version='1.0' encoding='utf-8'?><root><data name='unique_identifier'><value>Welcome to the Straker Translations API</value></data></root>",
                token = "9E839CBE-E581-4BB6-B5B792BF0E1C15B3"                
             };

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();


        }

    }
    

}
