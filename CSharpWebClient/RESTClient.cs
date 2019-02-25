using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // para cliente y funciones http
using System.Net.Http; // para cliente y funciones http
using System.Net.Http.Headers; // algunas características Headers
using System.Web;
using System.Web.Script.Serialization; // para serializer

using Laika;
using System.Json;



// Cllases para Job List
// objeto que devuelve la lista de trabajo por cortesía de json2csharp
// RootObjectJList
public class RootObjectJobList
{
    public List<Job> job { get; set; }
}
public class Job
{
    public string workflow { get; set; }
    public string job_key { get; set; }
    public string token { get; set; }
    public string sl { get; set; }
    public string review { get; set; }
    public string purchase_order { get; set; }
    public List<TranslatedFile> translated_file { get; set; }
    public string status { get; set; }
    public string tj_number { get; set; }
    public int wordcount { get; set; }
    public string created_at { get; set; }
    public int priority { get; set; }
    public string reserved_word { get; set; }
    public string source_file { get; set; }
    public string callback_uri { get; set; }
    public string title { get; set; }
    public int lead_time { get; set; }
    public string tl { get; set; }
    public string translation_type { get; set; }
    // for text response
    public List<TranslatedText> translated_text { get; set; }
    public string payload { get; set; }

}
public class TranslatedFile
{
    public string tl { get; set; }
    public string download_url { get; set; }
}

public class TranslatedText
{
    public string translation { get; set; }
    public string tl { get; set; }
}

public class JobList
{
    public string host { get; set; }
    public string token { get; set; }
    public string info { get; set; }
    public bool todoOK { get; set; }
    public RootObjectJobList RootJobList { get; set; }
    public JobList (string vhost, string vtoken)
    {
        host = vhost; token = vtoken;
        return;
    }

    public void ObtenListaJobs()
    {
        info = "OK"; // optimismo
        todoOK = true;
        RootJobList = new RootObjectJobList();
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(host); // "https://api.strakertranslations.com:443");


        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = client.GetAsync("/v3/translate").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                                                                                 // la forma síncrona (que hay que encapular en una "static async Task<xxx> Nombre(); es
                                                                                 // HttpResponseMessage response = await client.GetAsync(path);
                                                                                 //use JavaScriptSerializer from System.Web.Script.Serialization
        JavaScriptSerializer JSserializer = new JavaScriptSerializer();
        try
        {
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result; // sin asycn y con Result;
                RootJobList = JSserializer.Deserialize<RootObjectJobList>(data);
                info = CF.FormatOutput2HTML(data);

            }
            else
            {
                todoOK = false;
                info = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return;
            }
            //Make any other calls using HttpClient here.
            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        } finally
        {
            client.Dispose();
        }
        client.Dispose();
        // let see there is data
        if ( RootJobList.job == null  )
        {
            todoOK = false;
            info = string.Format("There are no jobs. If you have a token add jobs. If you dont have a toke get one from Strakker");
            return;
        }
        return;
    }
    public void ObtenListaJobs_OLD()
    {
        info = "OK"; // optimismo
        todoOK = true;
        RootJobList = new RootObjectJobList();
        HttpClient client = new HttpClient();
        var content = new MultipartFormDataContent();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "9E839CBE-E581-4BB6-B5B792BF0E1C15B3");
        client.BaseAddress = new Uri(host); // "https://api.strakertranslations.com:443");
        // Add an Accept header for JSON format.
        // no se si hace falta
        // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //

        HttpResponseMessage response = client.GetAsync("/v3/translate").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                                                                                 // la forma síncrona (que hay que encapular en una "static async Task<xxx> Nombre(); es
                                                                                 // HttpResponseMessage response = await client.GetAsync(path);
                                                                                 //use JavaScriptSerializer from System.Web.Script.Serialization
        JavaScriptSerializer JSserializer = new JavaScriptSerializer();
        if (response.IsSuccessStatusCode)
        {
            string data = response.Content.ReadAsStringAsync().Result; // sin asycn y con Result;
            RootJobList = JSserializer.Deserialize<RootObjectJobList>(data);            
            info = CF.FormatOutput2HTML(data);

        }
        else
        {
            todoOK = false;
            info = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        //Make any other calls using HttpClient here.
        //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();
        return;
    }
    
}



// JSON C# clasess represetnation


public class RootObjectLanguages
{
    public List<Language> languages { get; set; }
}
public class Language
{
    public string code { get; set; }
    public string name { get; set; }

}



public class LanguageList
{
    public RootObjectLanguages RootLanguages;
    public bool todoOK { get; set; }
    public string info { get; set; }
    public string host { get; set; }
    public LanguageList(string vhost)
    {
        host = vhost; info=""; todoOK = false;
        return;
    }
    public void ObtenLista2()
    {
        info = "OK"; // optimismo
        todoOK = true;
        RootLanguages = new RootObjectLanguages();
        var Languages = new List<Language>();
        var Language = new Language();
        Language.name = "English(UK)";Language.code = "English"; Languages.Add(Language);
        Language = new Language();
        Language.name = "Spanish (Spain)"; Language.code = "Spanish"; Languages.Add(Language);
        RootLanguages.languages = Languages;


        return;

    }
    public void ObtenLista()
    {
        info="OK"; // optimismo
        todoOK=true;
        RootLanguages = new RootObjectLanguages(); // objeto 
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(host); // "https://api.strakertranslations.com:443");
        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("/v3/languages").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                                                                                // la forma síncrona (que hay que encapular en una "static async Task<xxx> Nombre(); es
                                                                                // HttpResponseMessage response = await client.GetAsync(path);
                                                                                //use JavaScriptSerializer from System.Web.Script.Serialization
        JavaScriptSerializer JSserializer = new JavaScriptSerializer();
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            // dentro de tarea síncrona string data = await response.Content.ReadAsStringAsync();
            string data = response.Content.ReadAsStringAsync().Result; // sin asycn y con Result;
            RootLanguages= JSserializer.Deserialize<RootObjectLanguages>(data); // respuesta convertida en clase.
            // info= CF.FormatOutput2HTML(data); // Raw JSON Response
            
        }
        else
        {
            todoOK = false;
            info = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        //Make any other calls using HttpClient here.

      

        //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();


        return;

    }
}





public class RESTClient
{
    public string host;
    public int port;
    HttpClient client;
    public RESTClient(string hhost, int pport)
    {
        host = hhost;
        port = pport;
        
        client = new HttpClient(); // client here as any funciton can use it
        client.BaseAddress = new Uri(string.Format("https://{0}:{1}//v3/languages", host, port));
        // client.BaseAddress = new Uri("http://www.mknals.com:4031/");
        client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public void GetLanguages_old()
    {

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //foreach (var d in dataObjects)
            // {
            //    Console.WriteLine("{0}", d.Name);
            //}
            Console.WriteLine("Ha idio bien");
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
        client.Dispose();
    }
    public void GetLanguages()
    {
        try
        {
            using (client)
            {
                // var response = client.GetAsync("").Result;
                // string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                // o bien
                var response = client.GetStringAsync("").Result;
            }

        }
        catch (Exception ex)
        {
            var kkk = ex.Message.ToString();

        }




    }

  

 public void GetLanguages_v2()
{
    
    Task<int> kk = AccessTheWebAsync();

    async Task<int> AccessTheWebAsync()
    {
        HttpClient client = new HttpClient();
        Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");
        // podríamos hacer algo más
        //
        string urlContents = await getStringTask; // await espera getstring task
        return urlContents.Length;
    }
 }

  }

