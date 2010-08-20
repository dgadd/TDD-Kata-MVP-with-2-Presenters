using System;
using App.Support.Domain;

namespace App.Support.Repository
{
    public class InMemoryTempDataRepository : ITempDataRepository
    {
        public bool StoreMemberValues(Member member)
        {
            StoreMember.Member = member;
            return true;
        }

        public Member GetMemberValues()
        {
            return StoreMember.Member;
        }

        public static class StoreMember
        {
            public static Member Member { get; set; }
        }
    }
}