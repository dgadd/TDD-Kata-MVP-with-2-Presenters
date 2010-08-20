using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Support.Domain;
using App.Support.Presenter;
using App.Support.Repository;
using App.Support.View;

namespace Web_MVP
{
    public partial class _Default : System.Web.UI.Page, IGatherMemberInfoView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            new GatherMemberInfoPresenter(new SessionBasedTempDataRepository(Session), this);
        }

        protected void btnRenewGymMembership_Click(object sender, EventArgs e)
        {
            this.GatherMemberInfo(this, new GatherMemberInfoEventArgs
                                            {
                                                Member = new Member
                                                    {
                                                        FirstName = txtFirstName.Text,
                                                        LastName = txtLastName.Text,
                                                        GymMembershipId = txtGymMembershipID.Text
                                                    }
                                            });
        }

        public event EventHandler GatherMemberInfo;
        public void GoToNextView()
        {
            Response.Redirect("ProcessingGymMembership.aspx");
        }

    }
}
