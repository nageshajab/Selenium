using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class address : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn1"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"INSERT INTO [dbo].[employee] ([firstname],[lastname],[gender],[addressline1],[addressline2],[city],[state],[zipcode]) VALUES ('{Session["firstname"]}', '{Session["lastname"]}', '{Session["gender"]}','{addressline1.Text}', '{addressline2.Text}','{city.Text}','{state.Text}', '{zipcode.Text}')";

                    SqlCommand command = new SqlCommand(query);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    Response.Redirect("default.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message + ex.InnerException?.Message);
                }
            }
        }
    }
}