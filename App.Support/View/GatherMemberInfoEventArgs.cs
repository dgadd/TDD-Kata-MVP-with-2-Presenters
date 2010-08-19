using System;
using App.Support.Domain;

namespace App.Support.View
{
    public class GatherMemberInfoEventArgs : EventArgs
    {
        public Member Member { get; set; }
    }
}