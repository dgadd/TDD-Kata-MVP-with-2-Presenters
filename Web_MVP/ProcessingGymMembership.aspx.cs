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
    public partial class ProcessingGymMembership : System.Web.UI.Page, IRenewMembershipView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            new RenewMembershipPresenter(new SessionBasedTempDataRepository(Session), new FakeNationalFitnessGateway(),
                                         new FakeCCProcessingGateway(), new FakeMemberRepository(), this);
            this.Initialize(this, EventArgs.Empty);
        }


        public string Message
        {
            get { return null; }
            set { lblMessage.Text = value; }
        }

        public Member Member
        {
            get { return null; }
            set
            {
                var member = value;
                lblFirstName.Text = member.FirstName;
                lblLastName.Text = member.LastName;
                lblGymMembershipID.Text = member.GymMembershipId;
            }
        }

        public event EventHandler Initialize;
        public event EventHandler RenewMembership;

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            this.RenewMembership(this, EventArgs.Empty);
        }
    }
}
