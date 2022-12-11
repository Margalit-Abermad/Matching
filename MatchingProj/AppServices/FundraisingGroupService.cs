using AutoMapper;
using Common;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public class FundraisingGroupService : IFundraisingGroupService
{
    IFundraisingGroupRepository repo;
    IMapper mapper;

    public FundraisingGroupService(IFundraisingGroupRepository repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    #region GetAllFundraisingGroup

    public List<FundraisingGroupVM> GetList()
    {
        List<FundraisingGroupVM> fundraisingGroupVM = new List<FundraisingGroupVM>();
        foreach (var item in repo.GetAll())
        {
            fundraisingGroupVM.Add(new FundraisingGroupVM
            {
                Name = item.Name,
                AmountOfDonations = item.AmountOfDonations,
                Targets = (float)item.Target.TargetSum
            });

        }
        return fundraisingGroupVM;
    }

    #endregion

    #region GetFundraisingGroupById
    public FundraisingGroupVM GetById(int Id)
    {
        FundraisingGroupVM fundraisingGroupVM = new FundraisingGroupVM();
        var temp = repo.GetById(Id);
        fundraisingGroupVM.AmountOfDonations = temp.AmountOfDonations;
        fundraisingGroupVM.Name = temp.Name;
        //raisVM = repo.GetById(Id);
        return fundraisingGroupVM;
    }

    #endregion

    #region DeleteFundraising
    public void Delete(int Id)
    {
        repo.Delete(Id);
    }

    #endregion DeleteFundraising

    #region Update FundraisingGroup
    public void Update(FundraisingGroupVM fundraisingGroupVM)
    {
        FundraisingGroup fundraisingGroup = mapper.Map<FundraisingGroup>(fundraisingGroupVM);
        repo.Update(fundraisingGroup);
    }
    #endregion

    #region Create FundraisingGroup
    public void Create(FundraisingGroupVM fundraisingGroupVM)
    {
        FundraisingGroup fundraisingGroup = mapper.Map<FundraisingGroup>(fundraisingGroupVM);
        repo.Create(fundraisingGroup);
    }
    #endregion
}
