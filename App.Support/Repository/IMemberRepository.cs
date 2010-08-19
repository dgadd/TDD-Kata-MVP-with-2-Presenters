using App.Support.Domain;

namespace App.Support.Repository
{
    public interface IMemberRepository
    {
        void SaveMember(Member member);
    }
}