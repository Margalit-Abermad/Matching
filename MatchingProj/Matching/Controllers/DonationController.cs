using AppServices;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Matching.Controllers;

public class DonationController:BaseController
{
    IDonationService donationService;

    public DonationController(IDonationService donationService/*, IFile file*/)
    {
        this.donationService = donationService;
    }

    Files f =new Files();

    #region HttpGet
    [HttpGet]
    public ActionResult<List<DonationsVM>>GetAll()
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var donationList= donationService.GetList();
        if (donationList.Count==0)
        {
            return NoContent();
        }
        return Ok(donationList);
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        donationService.Delete(id);
    }
    #endregion

    #region HttpGetById
    [HttpGet("{id}")]
    public ActionResult<DonationsVM> GetById(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var dvm = donationService.GetById(id);
        if (dvm == null)
        {
            return NoContent();
        }
        return Ok(dvm);
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public void Update(DonationsVM donationsVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (donationsVM != null)
        {
            donationService.Update(donationsVM);
        }
        return;
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public void Create(DonationsVM donationsVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (donationsVM!=null)
        {
            donationService.Create(donationsVM);    
        }
        return;
    }
    #endregion
}
