using System;
using App.Support.Domain;

namespace App.Support.View
{
    public class FakeRenewMembershipView : IRenewMembershipView
    {
        public Member Member { get; set;}
        public event EventHandler Initialize;
        public event EventHandler RenewMembership;

        public string Message { get; set; }

        public void TriggerEvent_RenewMembership()
        {
            this.RenewMembership(this, EventArgs.Empty);
        }

        public void TriggerEvent_Initialize()
        {
            this.Initialize(this, EventArgs.Empty);
        }
    }
}