using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;



namespace CSharpWebClient
{
    public partial class mainV00 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lnkShowHidePanel.Text = "Click here to display REST settings";
                pnlSettings.Visible = false;
                lblCookie.Text = ""; // lblOut.Text = "";
                // Let's see If I have a cookie with settings
                HttpCookie myCookie = Request.Cookies["CSharpWebClientCookie"];
                if (myCookie != null)
                {
                    // cookie format OPENÇhostÇportÇch
                    string s = myCookie.Value;
                    string[] words = s.Split('#');
                    if (words.Count() == 3) // Cookie has 2 items
                    {
                        if (words[0].CompareTo("STRAKER") == 0) // first is open
                        {
                            txtHost.Text = words[1]; txtToken.Text = words[2];
                            //chkSendAll.Checked = words[3] == "1";  // true if 1
                            //chkAddInfo.Checked = words[4] == "1";  // true if 1
                            // chkSegmentBasedOnNewline.Checked = words[5] == "1";  // true if 1
                        }
                    }
                    else
                    {
                        lblCookie.Text += "<font color='red'>Ops.. wrong cookie.</font>" + "<br>";
                    }
                }

                lblCookie.Text += "Enter your settings and save them if you want so.";
                return;
            }
        }

        protected void lnkShowHidePanel_Click(object sender, EventArgs e)
        {
            if (pnlSettings.Visible)
            {
                pnlSettings.Visible = false;
                lnkShowHidePanel.Text = "Click here to display REST settings";

            }
            else
            {
                pnlSettings.Visible = true;
                lnkShowHidePanel.Text = "Click here to hide REST settings";
            }

        }

        protected void btnSaveCookies_Click(object sender, EventArgs e)
        {
            lblCookie.Text = "";
            Regex tengocedidlla = new Regex("ç");
            if (tengocedidlla.IsMatch(txtHost.Text + txtToken.Text))
            {
                lblCookie.Text = "<font color='red'>You cannot specifiy 'Ç' as it is used as separator</font>";
                return;
            }
            //int x;
            // Código por si hubiese una variable numérica
            //if (!(int.TryParse(txtPort.Text, out x) && x > 0))
            //{
            //    lblCookie.Text = String.Format("<font color='red'>Cannot convert '{0}' to a valid positive integer</font>", txtPort.Text);
            //    return;
            //}


            DateTime now = DateTime.Now;
            HttpCookie myCookie = Request.Cookies["CSharpWebClientCookie"];
            string textValue = "STRAKER" + "#" + txtHost.Text + "#" + txtToken.Text; 
            if (myCookie != null)
            {
                myCookie.Value = textValue;
                myCookie.Expires = now.AddYears(50); // Don't forget to reset the Expires property!
                Response.SetCookie(myCookie);
                lblCookie.Text = "<font color='green'>The cookie has been updated.</font>";
            }
            else
            { // does not exist
                myCookie = new HttpCookie("CSharpWebClientCookie");
                myCookie.Value = textValue;             // Set the cookie value.            
                myCookie.Expires = now.AddYears(50); // For a cookie to effectively never expire                
                Response.Cookies.Add(myCookie); // Add the cookie.
                lblCookie.Text = "<font color='green'>The cookie has been written.</font>";
            }

        }

        protected void lnkListAvailableLanguages_Click(object sender, EventArgs e)
        {
            // list of languages
            Session["host"] = txtHost.Text;
            Session["token"] = txtToken.Text;
            Response.Redirect("LanguagesList.aspx");         

        }

        protected void lnkbFileJob4Translation_Click(object sender, EventArgs e)
        {
            // Job for translation
            Session["host"] = txtHost.Text;
            Session["token"] = txtToken.Text;
            Response.Redirect("FileJob4Translation.aspx");
        }

        protected void Text4Translation_Click(object sender, EventArgs e)
        {
            // Text for translation
            Session["host"] = txtHost.Text;
            Session["token"] = txtToken.Text;
            Response.Redirect("Text4Translation.aspx");
        }

        protected void lnkbRetrieveJobs_Click(object sender, EventArgs e)
        {
            Session["host"] = txtHost.Text;
            Session["token"] = txtToken.Text;
            Response.Redirect("RetrieveJobs.aspx");
        }
    }
}