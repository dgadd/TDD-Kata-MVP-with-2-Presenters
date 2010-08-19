using System;

namespace App.Support.View
{
    public interface IGatherMemberInfoView
    {
         event EventHandler GatherMemberInfo;
        void GoToNextView();
    }
}