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
    public partial class AddEmployee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var firstname1 = firstname.Text;
            var lastname1 = lastname.Text;
            string gender=string.Empty;

            if(male.Checked)
                gender= "male";
            if (female.Checked)
                gender = "female";

            Session["firstname"] = firstname1;
            Session["lastname"] = lastname1;
            Session["gender"] = gender;

            Response.Redirect("address.aspx");
        }
    }
}