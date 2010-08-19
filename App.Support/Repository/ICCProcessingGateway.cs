namespace App.Support.Repository
{
    public interface ICCProcessingGateway
    {
        bool PayDuesByMembershipId(string gymMembershipId);
    }
}