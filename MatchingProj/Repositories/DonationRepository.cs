using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class DonationRepository : IDonationRepository
{
    MatchingContext context;

    public DonationRepository(MatchingContext context)
    {
        this.context = context;
    }

    #region Create Donation
    public void Create(Donation ObjToCreate/*, FundraisingGroup Obj2ToCreate*/)
    {
        context.Donations.Add(new Donation
        {
            DonatesName = ObjToCreate.DonatesName,
            AmountOfDonation = ObjToCreate.AmountOfDonation,
            DonationDate = DateTime.Now,
            FundRaiser = ObjToCreate.FundRaiser,//come null
            FundraisingGroup = ObjToCreate.FundraisingGroup,//come null
            FundRaiserId = 1,
            FundraisingGroupId = 1, 
        }) ;
        
        context.SaveChanges();//cant complit becose the foreign key is not full...
    }

    #endregion

    #region Delete Donation
    public void Delete(int Id)
    {
        var donationToDel=context.Donations.FirstOrDefault(d => d.Id == Id);
        if (donationToDel != null)
        {
            context.Donations.Remove(donationToDel);  
            context.SaveChanges();
        }
    }
    #endregion

    #region GetAll Donation
    public List<Donation> GetAll()
    {
        return context.Donations.Include(d => d.FundRaiser).Include(d=>d.FundraisingGroup).ToList();
    }

    #endregion

    #region GetById Donation
    public Donation GetById(int Id)
    {
        var donationId = context.Donations.Include(d=>d.FundRaiser).Include(d => d.FundraisingGroup).Where(d => d.Id == Id).FirstOrDefault();
        if (donationId != null)
        {
            return donationId;
        }
        return null;
    }

    #endregion

    #region Update Donation
    public void Update(Donation ObjToUpdate)
    {
        var getToUpd = context.Donations.Where(d => d.Id == ObjToUpdate.Id).FirstOrDefault();
        if (getToUpd != null)
        {
            getToUpd.DonationDate = ObjToUpdate.DonationDate;
            getToUpd.AmountOfDonation = ObjToUpdate.AmountOfDonation;
            getToUpd.FundRaiser=ObjToUpdate.FundRaiser;
            if (getToUpd.DonatesName != null)
            {
                getToUpd.DonatesName = ObjToUpdate.DonatesName;
            }
            else getToUpd.DonatesName = "ANONYMOUS";
            context.SaveChanges();
        }
    }
    #endregion
}
