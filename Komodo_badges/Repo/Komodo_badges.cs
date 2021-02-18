using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badges() { }

        public Badges(int badgeid, List<string> doorAccess)
        {
            BadgeID = badgeid;
            DoorAccess = doorAccess;
        }
    }
}