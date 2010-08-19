using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private event EventHandler GetCustomers;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            var branchId = Convert.ToInt32(txtBranchId.Text);
            this.GetCustomers(this, new GetCutomersEventArgs { BranchId = branchId });
        }
    }

    public class GetCutomersEventArgs : EventArgs
    {
        public int BranchId;
    }
}
