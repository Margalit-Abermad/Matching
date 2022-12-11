using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Raise
    {
        public Raise()
        {
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public double DonationsCollected { get; set; }
        public int FundraisingGroupId { get; set; }
        public double? RaisTarget { get; set; }
        public int PermissionId { get; set; }

        public virtual FundraisingGroup FundraisingGroup { get; set; } = null!;
        public virtual Permission Permission { get; set; } = null!;
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
