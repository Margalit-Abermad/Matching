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

public class DonationService : IDonationService
{
    IDonationRepository repo;
    IPermissionsRepository prepo;
    IMapper mapper;
    public DonationService(IDonationRepository repo, IPermissionsRepository prepo,IMapper mapper)
    {
        this.repo = repo;
        this.prepo = prepo;
        this.mapper = mapper;
    }


    #region GetAllDonations
    public List<DonationsVM> GetList()
    {
        List<Donation> donations = repo.GetAll();
        List<DonationsVM> donorsVM = mapper.Map<List<DonationsVM>>(donations);

        return donorsVM;
    }
    #endregion


    #region GetDonationById
    public DonationsVM GetById(int Id)
    {
        DonationsVM donationsVM = new DonationsVM();
        var temp = repo.GetById(Id);
        donationsVM.Id = temp.Id;
        donationsVM.AmountOfDonation = temp.AmountOfDonation;
        donationsVM.NameGroup = temp.FundraisingGroup.Name;
        donationsVM.FundRaiserName = $"{temp.FundRaiser.FirstName}{temp.FundRaiser.LastName}";
        donationsVM.DonationDate = temp.DonationDate;
        donationsVM.DonatesName = temp.DonatesName;
        donationsVM.FundraisingGroupId = temp.FundraisingGroupId;
        return donationsVM;
    }
    #endregion


    #region DeleteDonation and check permission

    //delete & check if you can delete the donation.
    public string Delete(int id, int permissionId, int password)
    {
        // DonationsVM donationsVM=new DonationsVM();
        permissionsVM permissionsVM = new permissionsVM();
        permissionsVM permissionsVM2 = new permissionsVM();


        if (permissionId == 3)
        {
            return permissionsVM.PermissionsDetails = prepo.GetPermissionsDetails(id);//return a messege of the permission of this user, here its cant delete!
        }
        if (permissionId == 2)
        {
            if (prepo.EqualsPassword(id, password))//check if the password is good for this user
            {
                return permissionsVM.PermissionsDetails = prepo.GetPermissionsDetails(id);//return a messege of the permission of this user- he can delete
                repo.Delete(id);//deleted the donation
            }
            //else ???
            else return "the password is not good!";
        }
        if (permissionId == 3)
        {
            if (prepo.EqualsPassword(id, password))//check if the password is good for this user
            {
                return permissionsVM.PermissionsDetails = prepo.GetPermissionsDetails(id);//return a messege of the permission of this user- he can delete
                repo.Delete(id);
            }
            else return "the password is not good!";
        }
        return "we are sorry!, you dont have the permission to delete this donation";//if its not 1, 2 or 3 - he is cand deledt!
    }

    #endregion

    #region OriginalDelete- will delete.....
    public void Delete(int Id)
    {
        repo.Delete(Id);
    }

    #endregion

    #region UpdateDonation
    public void Update(DonationsVM donationVM)
    {
        Donation donation = mapper.Map<Donation>(donationVM);
        repo.Update(donation);
    }

    #endregion

    #region CreateDonation
    public void Create(DonationsVM donationVM)
    {
        Donation donation = mapper.Map<Donation>(donationVM);
        repo.Create(donation);
    }
    #endregion
}
