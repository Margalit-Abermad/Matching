using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public class RaisProfile:Profile
{
    public RaisProfile()
    {
        CreateMap<Raise, RaiseVM>().ReverseMap().ReverseMap();

    }
}
