using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class FundraisingGroupRepository : IFundraisingGroupRepository
{
    MatchingContext context;

    public FundraisingGroupRepository(MatchingContext context)
    {
        this.context = context;
    }

    #region Create FundraisingGroup
    public void Create(FundraisingGroup ObjToCreate)
    {
        context.FundraisingGroups.Add(ObjToCreate);
        context.SaveChanges();
    }
    #endregion


    #region Delete FundraisingGroup
    public void Delete(int Id)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region GetAll FundraisingGroup
    public List<FundraisingGroup> GetAll()
    {
        return context.FundraisingGroups.Include(f => f.Target).ToList();
    }
    #endregion


    #region GetById FundraisingGroup
    public FundraisingGroup GetById(int Id)
    {
        var fundraisingGroupId = context.FundraisingGroups.Where(f => f.Id == Id).FirstOrDefault();
        if (fundraisingGroupId != null)
        {
            return fundraisingGroupId;
        }
        return null;
    }
    #endregion


    #region Update FundraisingGroup
    public void Update(FundraisingGroup ObjToUpdate)
    {
        var getToUpd = context.FundraisingGroups.Where(d => d.Id == ObjToUpdate.Id).FirstOrDefault();
        if (getToUpd != null)
        {
            getToUpd.Name = ObjToUpdate.Name;
            getToUpd.AmountOfDonations = ObjToUpdate.AmountOfDonations;
            getToUpd.TargetId = ObjToUpdate.TargetId;
            context.SaveChanges();
        }
    }
    #endregion
}
