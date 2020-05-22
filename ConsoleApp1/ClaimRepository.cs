using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimRepository
    {
        private Queue<Claim> _menuDirectory = new Queue<Claim>();

        public Queue<Claim> SeeAllClaims()
        {
            return _menuDirectory;
        }

        public Claim Peek()
        {
            if (_menuDirectory.Count == 0)
            {
                return null;
            }
            else
            {
                return _menuDirectory.Peek();
            }
        }

        public void Dequeue()
        {
            _menuDirectory.Dequeue();
        }

        public Claim TakeCareOfNextClaim()
        {
            foreach (Claim content in _menuDirectory)
            {
                return content;
            }
            return null;
        }

        public bool EnterNewClaim(Claim item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Enqueue(item);

            bool wasAdded = _menuDirectory.Count == startingCount + 1;

            return wasAdded;
        }
    }
}
