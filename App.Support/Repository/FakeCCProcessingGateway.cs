using System;

namespace App.Support.Repository
{
    public class FakeCCProcessingGateway : ICCProcessingGateway
    {
        public bool PayDuesByMembershipId(string gymMembershipId)
        {
            // the goal of a fake: happy test pass
            return true;
        }
    }
}