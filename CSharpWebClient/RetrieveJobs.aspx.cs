using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection; // para recuperar los tipos de job

namespace CSharpWebClient
{
    public partial class RetrieveJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblOut.Text = "";
                string host = Session["host"].ToString();
                string token = Session["token"].ToString();
                var instJobList = new JobList(host, token);
                instJobList.ObtenListaJobs();
                // instJobList.todoOK = true;
                if (!instJobList.todoOK)
                {
                    lblOut.Text = "<font color ='red'> Error retreiving job list." + "<br>";
                    lblOut.Text += instJobList.info + "</font> " + " < br >";
                    return;
                }
                // vamos a crea la tabla de datos y el datagrid view

                DataTable joblistTable = new DataTable();
                Job job = new Job();
                Type type = typeof(Job);
                PropertyInfo[] properties = type.GetProperties();
                DataTable dtt = new DataTable();

                BoundField campo;
                var campohlink = new HyperLinkField();

                foreach (PropertyInfo property in properties)
                {
                    // Debug info
                    // lblOut.Text += string.Format("{0} = {1} Type ({2})<br>", property.Name, property.GetValue(job, null),
                    //    property.PropertyType);
                    // 

                    campo = new BoundField();
                    campo.HeaderText = property.Name;
                    campo.DataField = property.Name;
                    campo.ReadOnly = true;
                    campo.Visible = true;

                    string FieldType = property.PropertyType.ToString();
                    switch (FieldType)
                    {
                        case "System.String":
                        case "System.Int32":
                            // add datatable column and gridviw column
                            dtt.Columns.Add(property.Name, property.PropertyType );
                            gdvJobs.Columns.Add(campo);
                            if (property.Name == "status") // the hyperlink
                            { //special case translation file after sattus
                              // we need to ad columns in the data table
                                dtt.Columns.Add("actual_hyperlink", property.PropertyType);
                                dtt.Columns.Add("translated_file", property.PropertyType);
                                dtt.Columns.Add("actionCan", property.PropertyType);
                                dtt.Columns.Add("actionCom", property.PropertyType);
                                dtt.Columns.Add("actual_translated_text", property.PropertyType);


                                // and alo in the gridview
                                campohlink = new HyperLinkField();
                                campohlink.HeaderText = "trans_file";
                                campohlink.DataTextField = "actual_hyperlink";
                                campohlink.DataNavigateUrlFields = new string[] { "actual_hyperlink" };
                                campohlink.DataNavigateUrlFormatString = "{0}";
                                gdvJobs.Columns.Add(campohlink);

                                campohlink = new HyperLinkField();
                                campohlink.HeaderText = "ComCom";
                                campohlink.DataTextField = "actionCom";
                                campohlink.DataTextFormatString = "{0}";
                                campohlink.DataNavigateUrlFields = new string[] { "job_key", "actionCom" };
                                campohlink.DataNavigateUrlFormatString = "ActionJob.aspx?job_key={0}&action={1}";
                                gdvJobs.Columns.Add(campohlink);


                                campohlink = new HyperLinkField();
                                campohlink.HeaderText = "Can";
                                campohlink.DataTextField = "actionCan";
                                campohlink.DataTextFormatString = "{0}";
                                campohlink.DataNavigateUrlFields = new string[] { "job_key", "actionCan" };
                                campohlink.DataNavigateUrlFormatString = "ActionJob.aspx?job_key={0}&action={1}";                                                               
                                gdvJobs.Columns.Add(campohlink);

                                                                campo = new BoundField();
                                campo.HeaderText = "actual_translated_text";
                                campo.DataField = "actual_translated_text"; 
                                campo.ReadOnly = true;
                                campo.Visible = true;
                                gdvJobs.Columns.Add(campo);

                            }
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }
                // ahora cumplimentamos la tabla cada trabajo es una nueva fila
                DataRow r; 
                foreach (Job j in instJobList.RootJobList.job)
                {
                    r = dtt.NewRow();
                    foreach (PropertyInfo property in properties)
                    {
                        // for debug
                        // lblOut.Text += string.Format("{0} = {1} Type ({2})<br>", property.Name, property.GetValue(j, null),
                        // property.PropertyType);
                        string FieldType = property.PropertyType.ToString();
                        switch (FieldType)
                        {
                            case "System.String":
                            case "System.Int32":
                                // dt.Columns.Add("code");
                                r[property.Name] = property.GetValue(j, null);
                                if (property.Name == "status")
                                {
                                    if (r[property.Name].ToString() == "COMPLETED" )
                                    {
                                        // translated we should look in the list
                                        if (j.translation_type == "file")
                                        {
                                            foreach (TranslatedFile tf in j.translated_file)
                                            {
                                                r["translated_file"] = tf.tl;
                                                r["actual_hyperlink"] = tf.download_url;
                                            }
                                        }
                                        if (j.translation_type == "text")
                                        {
                                            foreach (TranslatedText tf in j.translated_text)
                                            {
                                                r["actual_translated_text"] = tf.translation;
                                                
                                            }
                                        }

                                    } else if (r[property.Name].ToString() == "QUEUED") 
                                    {
                                        r["actionCan"] = "CANCEL";
                                        r["actionCom"] = "COMPLETE";
                                    }
                                }
                                break;

                            default:
                                //Console.WriteLine("Default case");
                                break;
                        }
                    }
                    dtt.Rows.Add(r);
                }


                // gdvJobs.DataSource = instJobList.RootJobList.job;
                gdvJobs.DataSource = dtt;
                gdvJobs.AutoGenerateColumns = false;
                gdvJobs.DataBind();
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("mainV00.aspx");
        }
    }
}