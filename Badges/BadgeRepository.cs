using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Badges
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();

        public bool CreateNewBadge(int badge, List<string> door)
        {
            int startingCount = _badgeDirectory.Count;

            _badgeDirectory.Add(badge, door);

            bool wasAdded = _badgeDirectory.Count == startingCount + 1;

            return wasAdded;
        }

        public void UpdateDoorOnExistingBadge(int badgeID, string doorAccess)
        {
            List<string> currentDoor = GetDoorAccess(badgeID);
            currentDoor.Add(doorAccess);
        }

        public List<string> GetDoorAccess(int badgeID)
        {
            List<string> doorAccess = new List<string>();
            if (_badgeDirectory.TryGetValue(badgeID, out doorAccess))
            {
                return doorAccess;
            }
            else
            {
                return null;
            }
        }

        public void DeleteDoorOfBadge(int badgeID, string doorAccess)
        {
            List<string> currentDoor = GetDoorAccess(badgeID);
            currentDoor.Remove(doorAccess);
        }

        public Dictionary<int, List<string>> ShowAllBadgeNumbersAndDoorAccess()
        { 
            return _badgeDirectory;
        }
    }
}
