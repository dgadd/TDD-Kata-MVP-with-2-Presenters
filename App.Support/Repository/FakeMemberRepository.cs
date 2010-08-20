using System;
using App.Support.Domain;

namespace App.Support.Repository
{
    public class FakeMemberRepository : IMemberRepository
    {
        public void SaveMember(Member member)
        {
            // the goal of a fake: happy test pass
        }
    }
}