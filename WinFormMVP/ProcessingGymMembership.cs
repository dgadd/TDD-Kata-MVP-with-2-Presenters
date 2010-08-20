using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App.Support.Domain;
using App.Support.Presenter;
using App.Support.Repository;
using App.Support.View;

namespace WinFormMVP
{
    public partial class ProcessingGymMembership : Form, IRenewMembershipView
    {
        public ProcessingGymMembership()
        {
            InitializeComponent();
            new RenewMembershipPresenter(new InMemoryTempDataRepository(), new FakeNationalFitnessGateway(),
                             new FakeCCProcessingGateway(), new FakeMemberRepository(), this);
            this.Initialize(this, EventArgs.Empty);
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.RenewMembership(this, EventArgs.Empty);
        }

        public event EventHandler RenewMembership;

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
                var crlf = System.Environment.NewLine;
                lblMemberDetails.Text = string.Format("First Name: {0}\r\nLast Name:{1}\r\nGym Membership ID:{2}", member.FirstName, member.LastName, member.GymMembershipId);
            }
        }

        public event EventHandler Initialize;
    }
}
