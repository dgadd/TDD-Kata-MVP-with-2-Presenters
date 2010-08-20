using System;
using System.Web;
using System.Web.SessionState;
using App.Support.Domain;

namespace App.Support.Repository
{
    public class FakeTempDataRepository : ITempDataRepository
    {
        private Member _member;

        // the goal of a fake: happy test pass
        public bool StoreMemberValues(Member member)
        {
            _member = member;
            return true;
        }

        public Member GetMemberValues()
        {
            return _member;
        }
    }
}