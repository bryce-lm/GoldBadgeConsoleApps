using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool IsValid { get; set; }

        public Claims() { }

        public Claims(int claimId, ClaimType claimType, string description, decimal price, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            Price = price;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            IsValid = isValid;
        }
    }
}