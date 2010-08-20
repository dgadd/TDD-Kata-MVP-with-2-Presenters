using System;
using App.Support.Domain;

namespace App.Support.Repository
{
    public class FakeNationalFitnessGateway : INationalFitnessGateway
    {
        public NationalFitnessResultsDTO VerifyMember(Member member)
        {
            // the goal of a fake: happy test pass
            return new NationalFitnessResultsDTO {IsVerified = true};
        }
    }
}