using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class TargetsRepository : ITargetRepository
{
    MatchingContext context;

    public TargetsRepository(MatchingContext context)
    {
        this.context = context;
    }

    #region Create Target
    public void Create(Target ObjToCreate)
    {
        context.Targets.Add(ObjToCreate);
        context.SaveChanges();
    }
    #endregion


    #region Delete Target
    public void Delete(int Id)
    {
        var targetToDel = context.Targets.FirstOrDefault(t => t.TargetId == Id);
        if (targetToDel != null)
        {
            context.Targets.Remove(targetToDel);
            context.SaveChanges();
        }
    }
    #endregion


    #region GetAll Target
    public List<Target> GetAll()
    {
        return context.Targets.ToList();
    }
    #endregion


    #region GetById Target
    public Target GetById(int Id)
    {
        var targetId = context.Targets.Where(t => t.TargetId == Id).FirstOrDefault();
        if (targetId != null)
        {
            return targetId;
        }
        return null;
    }

    #endregion


    #region Update Target
    public void Update(Target ObjToUpdate)
    {
        var getToUpd = context.Targets.Where(d => d.TargetId == ObjToUpdate.TargetId).FirstOrDefault();
        if (getToUpd != null)
        {
            getToUpd.TargetSum = ObjToUpdate.TargetSum;
            getToUpd.FundraisingId = getToUpd.FundraisingId;
            getToUpd.Collected = ObjToUpdate.Collected;
            getToUpd.MissingTrget = ObjToUpdate.MissingTrget;
            getToUpd.Deadline = ObjToUpdate.Deadline;
        }
        context.SaveChanges();
    }
    #endregion
}
