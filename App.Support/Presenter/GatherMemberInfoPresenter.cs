using System;
using App.Support.Repository;
using App.Support.View;

namespace App.Support.Presenter
{
    public class GatherMemberInfoPresenter
    {
        private readonly ITempDataRepository _tempDataRepository;
        private readonly IGatherMemberInfoView _gatherMemberInfoView;

        public GatherMemberInfoPresenter(ITempDataRepository tempDataRepository, IGatherMemberInfoView gatherMemberInfoView)
        {
            _tempDataRepository = tempDataRepository;
            _gatherMemberInfoView = gatherMemberInfoView;

            _gatherMemberInfoView.GatherMemberInfo += new EventHandler(_gatherMemberInfoView_GatherMemberInfo);
        }

        void _gatherMemberInfoView_GatherMemberInfo(object sender, EventArgs e)
        {
            var gmiea = (GatherMemberInfoEventArgs) e;
            var isSuccessful = _tempDataRepository.StoreMemberValues(gmiea.Member);
            _gatherMemberInfoView.GoToNextView();
        }
    }
}