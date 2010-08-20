using System;
using App.Support.Domain;

namespace App.Support.View
{
    public interface IRenewMembershipView
    {
        event EventHandler RenewMembership;
        string Message { get; set; }
        Member Member { get; set; }
        event EventHandler Initialize;
    }
}