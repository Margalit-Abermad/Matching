using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public class DonationsVM
{
    public int Id { get; set; }
    public int AmountOfDonation { get; set; }
    //public int FundRaiserId { get; set; }
    public string? FundRaiserName { get; set; }//AutoMapper ->  $"{item.FundRaiser.FirstName} {item.FundRaiser.LastName}"
    public string? NameGroup { get; set; }//AutoMapper -> $"{ item.FundraisingGroup.Name}"
    public int FundraisingGroupId { get; set; }
    public string? DonatesName { get; set; }//AutoMapper -> FullName = $"{item.DonatesName}"
    public DateTime DonationDate { get; set; }
}
