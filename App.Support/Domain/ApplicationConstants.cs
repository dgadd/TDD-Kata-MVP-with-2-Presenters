namespace App.Support.Domain
{
    public static class ApplicationConstants
    {
        public const string NATIONAL_FITNESS_MEMBERSHIP_NOT_VERIFIED = "National Fitness cannot verify your membership";
        public const string CC_CHARGES_NOT_APPROVED = "Your membership credit card renewal charges were not approved.";

        public static string FormatApprovalMessageForMember(Member member, bool isPaid)
        {
            return string.Format("Dues are paid for member {0} {1}, membership: {2}: {3}",
                                 member.FirstName,
                                 member.LastName,
                                 member.GymMembershipId,
                                 isPaid);
        }
    }
}