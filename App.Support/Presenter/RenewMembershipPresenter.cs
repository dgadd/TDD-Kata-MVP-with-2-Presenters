using System;
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

            _renewMembershipView.RenewMembership += new EventHandler(_renewMembershipView_RenewMembership);
        }

        void _renewMembershipView_RenewMembership(object sender, EventArgs e)
        {
            var member = _tempDataRepository.GetMemberValues();
            var nationalFitnessResultsDto = _nationalFitnessGateway.VerifyMember(member);
            var isPaid = _ccProcessingGateway.PayDuesByMembershipId(member.GymMembershipId);
            _memberRepository.SaveMember(member);
            _renewMembershipView.Message = string.Format("Are dues paid for member {0} {1}, membership: {2}: {3}",
                                                         member.FirstName,
                                                         member.LastName,
                                                         member.GymMembershipId,
                                                         isPaid);
        }
    }
}