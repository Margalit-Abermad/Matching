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

public class RaisService : IRaiseService
{
    IRaiseRepository repo;
    IMapper mapper;
    public RaisService(IRaiseRepository repo , IMapper mapper)
    {
        this.repo = repo;
        this.mapper = mapper;   
    }

    #region GetAll Raises
    public List<RaiseVM> GetList()
    {
        List<Raise> raises = repo.GetAll();
        List<RaiseVM> raiseVM = mapper.Map<List<RaiseVM>>(raises);
        return raiseVM;
    }
    #endregion

    #region GetById Raise
    public RaiseVM GetById(int Id)
    {
        RaiseVM raisVM = new RaiseVM();
        var temp=repo.GetById(Id);
        raisVM.FirstName = temp.FirstName;
        raisVM.LastName = temp.LastName;
        return raisVM;
    }
    #endregion

    #region Delete Raise
    public void Delete(int Id)
    {
        repo.Delete(Id);
    }
    #endregion

    #region Update Raise
    public void Update(RaiseVM raiseVM)
    {
        Raise raise = mapper.Map<Raise>(raiseVM);
        repo.Update(raise);   
    }
    #endregion

    #region Create Raise
    public void Create(RaiseVM raiseVM)
    {
        Raise raise=mapper.Map<Raise>(raiseVM); 
        repo.Create(raise); 
    }
    #endregion
}
