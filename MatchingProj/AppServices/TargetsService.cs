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


public class TargetsService : ITargetsService
{
    ITargetRepository repo;
    IMapper mapper;
    public TargetsService(ITargetRepository repo, IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;
    }

    #region Create Target
    public void create(TargetsVM targetsVM)
    {
        Target targets = mapper.Map<Target>(targetsVM);
        repo.Create(targets);
    }
    #endregion

    #region Delete Target
    public void Delete(int Id)
    {
        repo.Delete(Id);
    }
    #endregion

    #region GetById Target
    public TargetsVM GetById(int Id)
    {
        Target target = repo.GetById(Id);//get Target kind
        TargetsVM targetVM = mapper.Map<TargetsVM>(target);
        return targetVM;
    }
    #endregion

    #region GetAll Target
    public List<TargetsVM> GetList()
    {
        List<Target> targets = repo.GetAll();
        List<TargetsVM> targetsVM = mapper.Map<List<TargetsVM>>(targets);
        return targetsVM;
    }
    #endregion

    #region Update Target
    public void Update(TargetsVM targetsVM)
    {
        Target targets = mapper.Map<Target>(targetsVM);
        repo.Update(targets);
    }
    #endregion
}


