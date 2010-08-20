using System;
using App.Support.Domain;

namespace App.Support.View
{
    public class FakeGatherMemberInfoView : IGatherMemberInfoView
    {
        public FakeGatherMemberInfoView()
        {
            this.GoToNextViewMethodIsCalled = false;
        }

        public event EventHandler GatherMemberInfo;
        public void GoToNextView()
        {
            this.GoToNextViewMethodIsCalled = true;
        }

        public void TriggerEvent_GatherMemberInfo(Member member)
        {
            this.GatherMemberInfo(this, new GatherMemberInfoEventArgs {Member = member});
        }

        public bool GoToNextViewMethodIsCalled { get; set; }

    }
}