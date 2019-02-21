using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CSharpWebClient
{
    public partial class LanguagesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var DL = new LanguageList(Session["host"].ToString());
                lblOut.Text = "";
                DL.ObtenLista();
                if (!DL.todoOK) {
                    lblOut.Text = string.Format("<font color='red'>[{0}]</font>", DL.info);
                    return;
                }
                // we have de list
                DataTable dt = new DataTable();
                dt.Columns.Add("code");
                dt.Columns.Add("name");
                DataRow dr1;
                foreach (Language l in DL.RootLanguages.languages)
                {

                    dr1 = dt.NewRow();
                    dr1["code"] = l.code;
                    dr1["name"] = l.name;
                    dt.Rows.Add(dr1);
                }
                   
                BoundField campo = new BoundField();
                campo.HeaderText = "code";
                campo.DataField = "code";
                campo.ReadOnly = true;
                campo.Visible = true;
                gvLanguages.Columns.Add(campo);

               campo = new BoundField();
                campo.HeaderText = "name";
                campo.DataField = "name";
                campo.ReadOnly = true;
                campo.Visible = true;
                gvLanguages.Columns.Add(campo);

                gvLanguages.AutoGenerateColumns = false;             
                gvLanguages.DataSource = dt;
                gvLanguages.DataBind();
                lblOut.Text = DL.info;
                lblOut.Text += "<br>Done!";

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            Response.Redirect("mainV00.aspx");
        }
    }
}