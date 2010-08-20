using System;
using App.Support.Domain;
using App.Support.Repository;
using App.Support.View;

namespace App.Support.Presenter
{
    public class RenewMembershipPresenter
    {
        private readonly ITempDataRepository _tempDataRepository;
        private readonly INationalFitnessGateway _nationalFitnessGateway;
        private readonly ICCProcessingGateway _ccProcessingGateway;
        private readonly IMemberRepository _memberRepository;
        private readonly IRenewMembershipView _renewMembershipView;

        public RenewMembershipPresenter(ITempDataRepository tempDataRepository, INationalFitnessGateway nationalFitnessGateway, ICCProcessingGateway ccProcessingGateway, IMemberRepository memberRepository, IRenewMembershipView renewMembershipView)
        {
            _tempDataRepository = tempDataRepository;
            _nationalFitnessGateway = nationalFitnessGateway;
            _ccProcessingGateway = ccProcessingGateway;
            _memberRepository = memberRepository;
            _renewMembershipView = renewMembershipView;

            _renewMembershipView.Initialize += new EventHandler(_renewMembershipView_Initialize);
            _renewMembershipView.RenewMembership += new EventHandler(_renewMembershipView_RenewMembership);
        }

        void _renewMembershipView_Initialize(object sender, EventArgs e)
        {
            var member = _tempDataRepository.GetMemberValues();
            _renewMembershipView.Member = member;
        }

        void _renewMembershipView_RenewMembership(object sender, EventArgs e)
        {
            var member = _tempDataRepository.GetMemberValues();
            var nationalFitnessResultsDto = _nationalFitnessGateway.VerifyMember(member);
            if (!nationalFitnessResultsDto.IsVerified)
            {
                _renewMembershipView.Message = ApplicationConstants.NATIONAL_FITNESS_MEMBERSHIP_NOT_VERIFIED;
                return;
            }

            var isPaid = _ccProcessingGateway.PayDuesByMembershipId(member.GymMembershipId);
            if (!isPaid)
            {
                _renewMembershipView.Message = ApplicationConstants.CC_CHARGES_NOT_APPROVED;
                return;
            }

            _memberRepository.SaveMember(member);
            _renewMembershipView.Message = ApplicationConstants.FormatApprovalMessageForMember(member, isPaid);
        }


    }
}