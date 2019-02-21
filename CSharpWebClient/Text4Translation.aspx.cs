using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Laika;


namespace CSharpWebClient
{
    public partial class Text4Translation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaddw();
                // other default valures
                txtTitle.Text = "Translation job " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                txtToken.Text = ""; // not the straker token
                

            }
        }
        protected void cargaddw()
        {
            ListItem kk;
            // fisrt priority
            ddwPiority.Items.Clear();
            kk = new ListItem();
            kk.Text = "None"; ddwPiority.Items.Add(kk);
            for (int i = 1; i <= 5; i++)
            {
                kk = new ListItem();
                kk.Text = i.ToString(); ddwPiority.Items.Add(kk);
            }
            // 
            ddwWorkFlow.Items.Clear();
            kk = new ListItem(); kk.Text = "None"; ddwWorkFlow.Items.Add(kk);
            kk = new ListItem(); kk.Text = "TRANSLATION"; ddwWorkFlow.Items.Add(kk);
            kk = new ListItem(); kk.Text = "TRANSLATION_REVIEW"; ddwWorkFlow.Items.Add(kk);
            kk = new ListItem(); kk.Text = "TRANSLATION_REVIEW_VALIDATION"; ddwWorkFlow.Items.Add(kk);
            kk = new ListItem(); kk.Text = "TRANSLATION_VALIDATION"; ddwWorkFlow.Items.Add(kk);
            // languages
            var DL = new LanguageList(Session["host"].ToString());
            // DL.ObtenLista2(); // retreives only spa and eng
            DL.ObtenLista();
            if (!DL.todoOK)
            {
                lblOut.Text = string.Format("<font color='red'>[{0}]</font>", DL.info);
                return;
            }
            // we have de list
            ddwSource.Items.Clear();
            ddwTarget.Items.Clear();
            foreach (Language l in DL.RootLanguages.languages)
            {
                kk = new ListItem(); kk.Text = l.name; kk.Value = l.code; ddwSource.Items.Add(kk);
                kk = new ListItem(); kk.Text = l.name; kk.Value = l.code; ddwTarget.Items.Add(kk);
                // seleccionar inglés y spa                
            }
            int posi = 0;
            foreach (ListItem i in ddwSource.Items)
            {
                if (i.Value == "English") { ddwSource.SelectedIndex = posi; }
                posi++;
            }
            posi = 0;
            foreach (ListItem ii in ddwTarget.Items)
            {
                if (ii.Value == "Spanish") { ddwTarget.SelectedIndex = posi; }
                posi++;
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string auxS = "";
            lblOut.Text = "";
            // no se si va https://stackoverflow.com/questions/19141072/send-file-to-service-using-microsoft-net-http

            using (var client = new HttpClient()) // { 
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(txtTitle.Text) , "title"); 
                formData.Add(new StringContent(ddwSource.SelectedValue) , "sl"); 
                formData.Add(new StringContent(ddwTarget.SelectedValue) , "tl"); 
                if (ddwPiority.SelectedIndex >= 1)
                {
                    formData.Add(new StringContent(ddwPiority.SelectedValue), "priority");
                } 
                if (ddwWorkFlow.SelectedIndex >=1 )
                {
                    formData.Add(new StringContent(ddwWorkFlow.SelectedValue), "workflow");
                }
                auxS = txtUriCallBack.Text.Trim();
                if ( auxS != "" )
                {
                    formData.Add (new StringContent(auxS), "callback_uri");
                }
                auxS = txtToken.Text.Trim();
                if (auxS != "")
                {
                    formData.Add(new StringContent(auxS), "token");
                }
                auxS = txtReservedWords.Text.Trim();
                if (auxS != "")
                {
                    // aaa, bb, ccc 
                    formData.Add(new StringContent(auxS), "reserved_word");
                }
                auxS = txtPurchaseOrder.Text.Trim();
                if (auxS != "")
                {
                    // aaa, bb, ccc 
                    formData.Add(new StringContent(auxS), "purchase_order");
                }

                // last ting is the text  



                auxS = txtText4Translate.Text.Trim();
                auxS = CF.CleanInputString(auxS);
                if (auxS != "")
                {
                    // aaa, bb, ccc 
                    formData.Add(new StringContent(auxS), "payload");
                }


                client.BaseAddress = new Uri(Session["host"].ToString()); //  new Uri("https://sandbox.strakertranslations.com:443/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                    auxS = "";
                try
                {
                    var response = client.PostAsync("/v3/translate/text", formData).Result;
                    
                    if (!response.IsSuccessStatusCode)
                    {
                        auxS += string.Format("<font color='red'>[{0}]</font>", "Response error") + "<br>"; 
                    }
                    auxS= response.Content.ReadAsStringAsync().Result;
                    auxS  = string.Format("<font color='green'>[{0}]</font>", CF.FormatOutput2HTML(auxS));
                    }
                catch (Exception Error)
                {
                    auxS= string.Format("<font color='red'>[{0}]</font>",Error.Message) +"<br>";
                    return;
                }
                finally
                {
                    client.CancelPendingRequests();
                    lblOut.Text += auxS;
                        // restauro cabecera título
                    txtTitle.Text = "Translation job " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                    }
                }
            // }
        }

        protected void btnSend_Click_old(object sender, EventArgs e)
        {
            string textfileinstring = ""; // =  File.ReadAllText(string.Format ("{0}", FileName));
        
            var content = new MultipartFormDataContent();


            var values = new Dictionary<string, string>
            {
                { "title", txtTitle.Text  },
                { "sl", ddwSource.SelectedValue },
                { "tl", ddwTarget.SelectedValue  },
                { "source_file", textfileinstring}
            };

            using (var stream = new FileStream("example.xml", FileMode.Open))
            {
                StreamContent sc = new StreamContent(stream);
            }


            foreach (var keyValuePair in values)
            {
                content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
            }
            HttpClient client2 = new HttpClient();
            // client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "9E839CBE-E581-4BB6-B5B792BF0E1C15B3") ;
            client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + "9E839CBE-E581-4BB6-B5B792BF0E1C15B3");
            // https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient
            client2.BaseAddress = new Uri(Session["host"].ToString());   // new Uri("https://sandbox.strakertranslations.com:443/");
            var response2 = client2.PostAsync("/v3/translate/file", content).Result;
            var responseString = response2.Content.ReadAsStringAsync().Result;
             lblOut.Text= CF.FormatOutput2HTML(responseString);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mainV00.aspx");
        }
    }
}