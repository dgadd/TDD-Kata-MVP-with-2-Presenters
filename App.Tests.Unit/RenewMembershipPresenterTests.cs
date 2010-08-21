using System;
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
    public class RenewMembershipPresenterTests
    {
        private MockRepository _mockRepository;
        private ITempDataRepository _tempDataRepository;
        private INationalFitnessGateway _nationalFitnessGateway;
        private ICCProcessingGateway _ccProcessingGateway;
        private IMemberRepository _memberRepository;
        private IRenewMembershipView _renewMembershipView;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _tempDataRepository = _mockRepository.StrictMock<ITempDataRepository>();
            _nationalFitnessGateway = _mockRepository.StrictMock<INationalFitnessGateway>();
            _ccProcessingGateway = _mockRepository.StrictMock<ICCProcessingGateway>();
            _memberRepository = _mockRepository.StrictMock<IMemberRepository>();
            _renewMembershipView = _mockRepository.StrictMock<IRenewMembershipView>();
        }

        [Test]
        public void InitializeEvent_NoInput_RepopulatesViewFromTempRepository()
        {
            // define out expectations (of how the Presenter will coordinate the interfaces
            _renewMembershipView.Initialize += null;
            var initializeEvent = LastCall.IgnoreArguments().GetEventRaiser();
            _renewMembershipView.RenewMembership += null;
            LastCall.IgnoreArguments();

            const string firstName = "Sally";
            const string lastName = "Wong";
            const string gymMembershipId = "AB1234";
            var member = new Member { FirstName = firstName, LastName = lastName, GymMembershipId = gymMembershipId };
            Expect.Call(_tempDataRepository.GetMemberValues()).Return(member);

            // the retrieved member information from the _tempDataRepository 
            // is now assigned to the view (where it's properties can be assigned to various controls)
            _renewMembershipView.Member = member;

            _mockRepository.ReplayAll();

            var sut = new RenewMembershipPresenter(_tempDataRepository, _nationalFitnessGateway,
                                                   _ccProcessingGateway, _memberRepository, _renewMembershipView);
            initializeEvent.Raise(_renewMembershipView, EventArgs.Empty);

            _mockRepository.VerifyAll();            
        }

        [Test]
        public void RenewMembershipEvent_MemberInput_InstructsToGoToNextView()
        {
            // define out expectations (of how the Presenter will coordinate the interfaces
            _renewMembershipView.Initialize += null;
            LastCall.IgnoreArguments();
            _renewMembershipView.RenewMembership += null;
            var renewMembershipEvent = LastCall.IgnoreArguments().GetEventRaiser();

            const string firstName = "Sally";
            const string lastName = "Wong";
            const string gymMembershipId = "AB1234";
            var member = new Member { FirstName = firstName, LastName = lastName, GymMembershipId = gymMembershipId };
            Expect.Call(_tempDataRepository.GetMemberValues()).Return(member);

            var nationalFitnessResultsDto = new NationalFitnessResultsDTO {IsVerified = true};
            Expect.Call(_nationalFitnessGateway.VerifyMember(member)).Return(nationalFitnessResultsDto);
            
            const bool isPaid = true;
            Expect.Call(_ccProcessingGateway.PayDuesByMembershipId(member.GymMembershipId)).Return(isPaid);

            _memberRepository.SaveMember(member);

            _renewMembershipView.Message = ApplicationConstants.FormatApprovalMessageForMember(member, isPaid);
            _mockRepository.ReplayAll();

            var sut = new RenewMembershipPresenter(_tempDataRepository, _nationalFitnessGateway,
                                                   _ccProcessingGateway, _memberRepository, _renewMembershipView);
            renewMembershipEvent.Raise(_renewMembershipView, EventArgs.Empty);

            _mockRepository.VerifyAll();
        }
    }
}
