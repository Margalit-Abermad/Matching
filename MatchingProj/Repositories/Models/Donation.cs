using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Donation
    {
        public int Id { get; set; }
        public int AmountOfDonation { get; set; }
        public int FundRaiserId { get; set; }
        public int FundraisingGroupId { get; set; }
        public DateTime DonationDate { get; set; }
        public string? DonatesName { get; set; }

        public virtual Raise FundRaiser { get; set; } = null!;
        public virtual FundraisingGroup FundraisingGroup { get; set; } = null!;
    }
}
