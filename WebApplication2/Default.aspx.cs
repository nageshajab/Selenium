using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Model;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn1"].ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT firstname,lastname,gender,addressline1,city,state FROM [dbo].[employee]";
                SqlDataReader reader = command.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    employees.Add(new Employee()
                    {
                        Firstname = reader.GetString(0),
                        lastname = reader.GetString(1),
                        gender = reader.GetString(2),
                        addressline1 = reader.GetString(3),
                        city=reader.GetString(4),
                        state=reader.GetString(5)
                    });
                }
                grid1.DataSource = employees;
                grid1.DataBind();
            }
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addemployee.aspx");
        }
    }
}