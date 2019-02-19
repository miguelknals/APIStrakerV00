using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization; // para serializer, añadir system.web.extensions 
using System.Diagnostics; // pruebas de stopwatch

namespace StrakerAPIConsoleClient
{
    

    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public List<Language> languages { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<RootObject> GetProductAsync(string path)
        {
            Console.WriteLine("Inicio tarea asíncrona GetProduyAyunc");
            RootObject products = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                //  product = await response.Content.ReadAsAsync<Product>();
                string data = await response.Content.ReadAsStringAsync();
                //use JavaScriptSerializer from System.Web.Script.Serialization
                JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                //deserialize to your class
                products = JSserializer.Deserialize<RootObject>(data);

                foreach (var d in products.languages)
                {
                   // Console.WriteLine("{0}", d.name);
                }
            }
            Console.WriteLine("Fin GetProduyAyunc");
            return products;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("llamo a runasyc");
            // RunAsync().GetAwaiter().GetResult();
            var stopwatch = new Stopwatch(); stopwatch.Start();
            Task tarea = RunAsync();
            Console.WriteLine("Tarea asyncrona iniciada (si realmente es asincrona debería aparecer antes de tareas Runasycn");
            tarea.Wait();
            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine(elapsed_time);
            Console.WriteLine("Fin");
            Console.ReadLine();
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Inicio tarea async");
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://api.strakertranslations.com:443/v3/languages");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {


                // Get the product
                Console.WriteLine("Inicio GetProducAscyn con await hasta fin");
                var products = await GetProductAsync("");
                Console.WriteLine("Fin de await  GetProducAscyn");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
