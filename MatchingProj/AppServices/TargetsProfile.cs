using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public class TargetsProfile:Profile
{
    public TargetsProfile()
    {
        CreateMap<Target, TargetsVM>().ReverseMap().ReverseMap();
    }

}
