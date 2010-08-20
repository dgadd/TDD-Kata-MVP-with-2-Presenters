using System;
using System.Web.SessionState;
using App.Support.Domain;

namespace App.Support.Repository
{
    public class SessionBasedTempDataRepository : ITempDataRepository
    {
        private readonly HttpSessionState _session;

        public SessionBasedTempDataRepository(HttpSessionState session)
        {
            _session = session;
        }

        public bool StoreMemberValues(Member member)
        {
            _session["member"] = member;
            return true;
        }

        public Member GetMemberValues()
        {
            return (Member) _session["member"];
        }
    }
}