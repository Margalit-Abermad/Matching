using AppServices;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Matching.Controllers;

public class FundraisingGroupController:BaseController
{
    IFundraisingGroupService fundraisingGroupService;

    public FundraisingGroupController(IFundraisingGroupService fundraisingGroupService)
    {
        this.fundraisingGroupService = fundraisingGroupService;
    }

    Files f=new Files();

    #region HttpGet
    [HttpGet]
    public ActionResult<List<FundraisingGroupVM>> GetAll()
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var fundraisingGroupList = fundraisingGroupService.GetList();
        if (fundraisingGroupList.Count == 0)
        {
            return NoContent();
        }
        return Ok(fundraisingGroupList);
    }
    #endregion

    #region HttpGetById
    [HttpGet("{id}")]
    public ActionResult<FundraisingGroupVM> GetById(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var fvm = fundraisingGroupService.GetById(id);
        if (fvm == null)
        {
            return NoContent();
        }
        return Ok(fvm);
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public void Create(FundraisingGroupVM fundraisingGroupVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (fundraisingGroupVM != null)
        {
            fundraisingGroupService.Create(fundraisingGroupVM);
        }
        return;
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        fundraisingGroupService.Delete(id);
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public void Update(FundraisingGroupVM fundraisingGroupVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (fundraisingGroupVM != null)
        {
            fundraisingGroupService.Update(fundraisingGroupVM);
        }
        return ;
    }
    #endregion
}
