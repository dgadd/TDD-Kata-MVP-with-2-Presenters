using App.Support.Domain;

namespace App.Support.Repository
{
    public interface INationalFitnessGateway
    {
        NationalFitnessResultsDTO VerifyMember(Member member);
    }
}