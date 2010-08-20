using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Support.Domain;
using App.Support.Presenter;
using App.Support.Repository;
using App.Support.View;
using NUnit.Framework;

namespace App.Tests.Integration
{
    [TestFixture]
    public class Renewal_EndToEndIntegrationTests
    {
        private ITempDataRepository _tempDataRepository;
        private IGatherMemberInfoView _gatherMemberInfoView;
        private INationalFitnessGateway _nationalFitnessGateway;
        private ICCProcessingGateway _ccProcessingGateway;
        private IMemberRepository _memberRepository;
        private IRenewMembershipView _renewMembershipView;

        [SetUp]
        public void SetUp()
        {
            _tempDataRepository = new FakeTempDataRepository();
            _gatherMemberInfoView = new FakeGatherMemberInfoView();
            _nationalFitnessGateway = new FakeNationalFitnessGateway();
            _ccProcessingGateway = new FakeCCProcessingGateway();
            _memberRepository = new FakeMemberRepository();
            _renewMembershipView = new FakeRenewMembershipView();
        }

        [Test]
        public void EndToEnd_BothViews_DataIsStoredRetrievedApprovedAndSaved()
        {
            const string firstName = "John";
            const string lastName = "Smith";
            const string gymMembershipId = "ABCD1234";
            var member = new Member {FirstName = firstName, LastName = lastName, GymMembershipId = gymMembershipId};

            var sutPage1 = new GatherMemberInfoPresenter(_tempDataRepository, _gatherMemberInfoView);
            var fakeView1 = (FakeGatherMemberInfoView) _gatherMemberInfoView;
            fakeView1.TriggerEvent_GatherMemberInfo(member);

            Assert.IsTrue(fakeView1.GoToNextViewMethodIsCalled);

            var sutPage2 = new RenewMembershipPresenter(_tempDataRepository, _nationalFitnessGateway,
                                                        _ccProcessingGateway, _memberRepository, _renewMembershipView);
            var fakeView2 = (FakeRenewMembershipView) _renewMembershipView;

            fakeView2.TriggerEvent_Initialize();
            Assert.AreEqual(member, _renewMembershipView.Member);

            fakeView2.TriggerEvent_RenewMembership();

            const bool isPaid = true;
            var expectedFinalMessage = ApplicationConstants.FormatApprovalMessageForMember(member, isPaid);

            Assert.AreEqual(member, _renewMembershipView.Member);
            Assert.AreEqual(expectedFinalMessage, fakeView2.Message);
        }
    }
}
