using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Support.Domain;
using App.Support.Presenter;
using App.Support.Repository;
using App.Support.View;
using NUnit.Framework;
using Rhino.Mocks;

namespace App.Tests.Unit
{
    [TestFixture]
    public class GatherMemberInfoPresenterTests
    {
        private MockRepository _mockRepository;
        private ITempDataGateway _tempDataGateway;
        private IGatherMemberInfoView _gatherMemberInfoView;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _tempDataGateway = _mockRepository.StrictMock<ITempDataGateway>();
            _gatherMemberInfoView = _mockRepository.StrictMock<IGatherMemberInfoView>();
        }

        [Test]
        public void GatherMemberInfoEvent_MemberInput_InstructsToGoToNextView()
        {
            // define out expectations (of how the Presenter will coordinate the interfaces
            _gatherMemberInfoView.GatherMemberInfo += null;
            var gatherMemberInfoEvent = LastCall.IgnoreArguments().GetEventRaiser();

            const string firstName = "Sally";
            const string lastName = "Wong";
            const string gymMembershipId = "AB1234";
            var member = new Member { FirstName = firstName, LastName = lastName, GymMembershipId = gymMembershipId };
            Expect.Call(_tempDataGateway.StoreMemberValues(member)).Return(true);
            _gatherMemberInfoView.GoToNextView();



            // put the mock into replay (instantiate the presenter)
            _mockRepository.ReplayAll();

            var sut = new GatherMemberInfoPresenter(_tempDataGateway, _gatherMemberInfoView);
            gatherMemberInfoEvent.Raise(_gatherMemberInfoView, new GatherMemberInfoEventArgs { Member = member });

            // verify the mock
            _mockRepository.VerifyAll();
        }
    }
}
