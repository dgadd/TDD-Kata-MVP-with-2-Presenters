using System;
using App.Support.Repository;
using App.Support.View;

namespace App.Support.Presenter
{
    public class GatherMemberInfoPresenter
    {
        private readonly ITempDataGateway _tempDataGateway;
        private readonly IGatherMemberInfoView _gatherMemberInfoView;

        public GatherMemberInfoPresenter(ITempDataGateway tempDataGateway, IGatherMemberInfoView gatherMemberInfoView)
        {
            _tempDataGateway = tempDataGateway;
            _gatherMemberInfoView = gatherMemberInfoView;

            _gatherMemberInfoView.GatherMemberInfo += new EventHandler(_gatherMemberInfoView_GatherMemberInfo);
        }

        void _gatherMemberInfoView_GatherMemberInfo(object sender, EventArgs e)
        {
            var gmiea = (GatherMemberInfoEventArgs) e;
            var isSuccessful = _tempDataGateway.StoreMemberValues(gmiea.Member);
            _gatherMemberInfoView.GoToNextView();
        }
    }
}