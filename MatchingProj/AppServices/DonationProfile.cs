using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<Donation, DonationsVM>()
           .ForMember(m => m.FundRaiserName, vm => vm
           .MapFrom(m => $"{m.FundRaiser.FirstName} {m.FundRaiser.LastName}"))
           .ForMember(m => m.NameGroup, vm => vm
           .MapFrom(m => $"{ m.FundraisingGroup.Name}"))
           .ReverseMap();
        }
    }
}
