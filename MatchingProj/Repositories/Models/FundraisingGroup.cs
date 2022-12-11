using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class FundraisingGroup
    {
        public FundraisingGroup()
        {
            Donations = new HashSet<Donation>();
            Raises = new HashSet<Raise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AmountOfDonations { get; set; }
        public int TargetId { get; set; }

        public virtual Target Target { get; set; } = null!;
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Raise> Raises { get; set; }
    }
}
