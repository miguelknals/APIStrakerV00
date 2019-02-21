using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Laika;


namespace CSharpWebClient
{
    public partial class ActionJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // voy a leer el job_key
                string job = Request.Params["job_key"];
                string action = Request.Params["action"];
                ActionJoProcedure(job, action);


            }

        }
        void ActionJoProcedure(string job, string action)
        {

            HttpContent stringContentJob = new StringContent(job); // Le contenu du paramètre P1
            using (var client = new HttpClient())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(stringContentJob, "job_key");
                    client.BaseAddress = new Uri(Session["host"].ToString()); // "new Uri("https://sandbox.strakertranslations.com:443/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                    string auxS = "";
                    try
                    {
                        // action it shoubd be "CANCEL" or "COMPLETE"
                        string auxS2 = "";
                        if  (action == "CANCEL")
                        {
                            auxS2 = "/v3/translate/cancel";
                            
                        } else if (action == "COMPLETE")
                        {
                            auxS2 = "v3/translate/complete";                                               
                        }  else
                        {
                            lblOut.Text += string.Format("<font color='red'>[{0}]</font>", "Internal error action should be CANCEL or COMPLETE");
                            return;
                        }

                        var response = client.PostAsync(auxS2, formData).Result;

                        if (!response.IsSuccessStatusCode)
                        {
                            auxS += string.Format("<font color='red'>[{0}]</font>", "Response error") + "<br>";
                        }
                        auxS = response.Content.ReadAsStringAsync().Result;
                        auxS = string.Format("<font color='green'>[{0}]</font>", CF.FormatOutput2HTML(auxS));
                    }
                    catch (Exception Error)
                    {
                        auxS = string.Format("<font color='red'>[{0}]</font>", Error.Message) + "<br>";
                        return;
                    }
                    finally
                    {
                        client.CancelPendingRequests();
                        lblOut.Text += auxS;
                        // restauro cabecera título
                        

                    }
                }


                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RetrieveJobs.aspx");
        }
    }
}