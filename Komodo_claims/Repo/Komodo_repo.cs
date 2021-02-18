using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public class Repository
    {
        private Queue<Claims> _claims = new Queue<Claims>();
        public Queue<Claims> GetList()
        {
            return _claims; 
        }

        public void AddClaim(Claims newClaim)
        {
            _claims.Enqueue(newClaim); 
        }

        public void RemoveClaim()
        {
            _claims.Dequeue(); 
        }

        public void IsValid(Claims claim) 
        {
            if (claim.ClaimDate < claim.IncidentDate)

                    claim.ClaimDate = claim.IncidentDate;

            TimeSpan difference = (claim.ClaimDate - claim.IncidentDate);

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }
    }
}