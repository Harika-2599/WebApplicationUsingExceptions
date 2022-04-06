using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplicationUsingExceptions
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("getEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
            catch(Exception ex)
            {
                // Console.WriteLine("Error Occured");
                Response.Write("Error");
            }


        }
    }
}
