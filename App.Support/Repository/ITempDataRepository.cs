using App.Support.Domain;

namespace App.Support.Repository
{
    public interface ITempDataRepository
    {
        bool StoreMemberValues(Member member);
        Member GetMemberValues();
    }
}