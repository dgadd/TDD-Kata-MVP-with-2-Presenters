using App.Support.Domain;

namespace App.Support.Repository
{
    public interface ITempDataGateway
    {
        bool StoreMemberValues(Member member);
    }
}