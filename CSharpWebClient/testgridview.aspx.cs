using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CSharpWebClient
{
    public partial class testgridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t.Columns.Add("col1");
            t.Columns.Add("col2");
            DataRow r;
            r = t.NewRow();
            r["col1"] = "fila 1 1"; r["col2"] = "fila 1 2"; t.Rows.Add(r);
            r = t.NewRow();
            r["col1"] = "fila 2 1"; r["col2"] = "fila 2 2"; t.Rows.Add(r);

            var campo = new BoundField();
            campo.HeaderText = "Columna 1";
            campo.DataField = "col1";
            campo.ReadOnly = true;
            campo.Visible = true;
            gdv.Columns.Add(campo);

            var campoB = new HyperLinkField();
            campoB.HeaderText = "Columna hiper";
            campoB.DataTextField = "col1";
            campoB.DataNavigateUrlFields = new string[] { "col1" };
            campoB.DataNavigateUrlFormatString = "names.aspx?col1={0}";
           
            gdv.Columns.Add(campoB);

            gdv.DataSource= t;
            gdv.DataBind();

        }
    }
}