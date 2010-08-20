using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ProcessGymMembership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFirstName.Text = Session["FirstName"].ToString();
            lblLastName.Text = Session["LastName"].ToString();
            lblGymMembershipID.Text = Session["GymMembershipID"].ToString();
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            // step 1: call to a centralized national fitness web service for approval

            // step 2: call to credit card service for renewal by membership ID

            // step 3: save membership renewal information to the database

            // step 4: write the result to the page
            lblMessage.Text = "Your gym membership is renewed for another year";
        }
    }
}
