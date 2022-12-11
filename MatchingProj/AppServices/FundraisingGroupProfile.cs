using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

    public class FundraisingGroupProfile:Profile
    {
        public FundraisingGroupProfile()
        {
            CreateMap<FundraisingGroup, FundraisingGroupVM>().ReverseMap();

        }
    }

