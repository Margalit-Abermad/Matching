using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class RaiseRepository : IRaiseRepository
{

    MatchingContext context;

    public RaiseRepository(MatchingContext context)
    {
        this.context = context;
    }

    #region Create Raises
    public void Create(Raise ObjToCreate) //to cheek if not miss nothing!
    {
        context.Raises.Add(new Raise
        {
            FirstName = ObjToCreate.FirstName,
            LastName = ObjToCreate.LastName,
            DonationsCollected = ObjToCreate.DonationsCollected,
            FundraisingGroupId = ObjToCreate.FundraisingGroupId,
        });
    }
    #endregion

    #region Delete Raises
    public void Delete(int Id)
    {
        var raisToDel = context.Raises.FirstOrDefault(x => x.Id == Id);
        if (raisToDel != null)
        {
            context.Remove(raisToDel);
        }
    }

    #endregion

    #region GetAll Raises
    public List<Raise> GetAll()
    {
        return context.Raises.ToList();
    }
    #endregion

    #region GetById Raises
    public Raise GetById(int Id)
    {
        var raiseById = context.Raises.FirstOrDefault(x => x.Id == Id);
        if (raiseById != null)
        {
            return raiseById;
        }
        return null;
    }
    #endregion

    #region Update Raises
    public void Update(Raise ObjToUpdate)
    {
        var raisToUpd=context.Raises.FirstOrDefault(x => x.Id == ObjToUpdate.Id);
        if (raisToUpd != null)
        {
            raisToUpd.FundraisingGroup = ObjToUpdate.FundraisingGroup;
            raisToUpd.FundraisingGroupId = ObjToUpdate.FundraisingGroupId;
            raisToUpd.LastName = ObjToUpdate.LastName;
            raisToUpd.FirstName = ObjToUpdate.FirstName;
            raisToUpd.DonationsCollected=ObjToUpdate.DonationsCollected;
        }
    }
    #endregion
}
