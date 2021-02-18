using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class Repository
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> GetDictonary() 
        {
            return _doorAccess;
        }

        public void AddBadge(Badges badge)
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        public void GiveAccess(int badgeid, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }

        public void RemoveAccess(int badgeid, string doorAccess)
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Remove(doorAccess);
        }
    }
}