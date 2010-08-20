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
    public partial class Form1 : Form, IGatherMemberInfoView
    {
        public Form1()
        {
            InitializeComponent();
            new GatherMemberInfoPresenter(new InMemoryTempDataRepository(), this);
        }

        private void btnRenewGymMembership_Click(object sender, EventArgs e)
        {
            this.GatherMemberInfo(this, new GatherMemberInfoEventArgs
            {
                Member = new Member
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    GymMembershipId = txtGymMembershipId.Text
                }
            });
        }

        public event EventHandler GatherMemberInfo;
        public void GoToNextView()
        {
            var nextWindow = new ProcessingGymMembership();
            nextWindow.Show();
        }
    }
}
