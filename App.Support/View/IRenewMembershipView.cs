using System;

namespace App.Support.View
{
    public interface IRenewMembershipView
    {
        event EventHandler RenewMembership;
        string Message { get; set; }
    }
}