using AppServices;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Matching.Controllers;

public class TargetsController:BaseController
{
    ITargetsService targetService;

    public TargetsController(ITargetsService targetService)
    {
        this.targetService = targetService;
    }

    Files f=new Files();

    #region HttpGet
    [HttpGet]
    public ActionResult<List<FundraisingGroupVM>> GetAll()
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var targetsList = targetService.GetList();
        if (targetsList.Count == 0)
        {
            return NoContent();
        }
        return Ok(targetsList);
    }
    #endregion

    #region HttpGet
    [HttpGet("{id}")]
    public ActionResult<FundraisingGroupVM> GetById(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var tvm = targetService.GetById(id);
        if (tvm==null)
        {
            return NoContent();
        }
        return Ok(tvm);
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public void Create(TargetsVM targetsVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        //WriteToFile(url);
        f.Dofile(url);
        if (targetsVM != null)
        {
            targetService.create(targetsVM);
        }
        return;
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public void Update(TargetsVM targetsVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (targetsVM != null)
        {
            targetService.Update(targetsVM);
        }
        return ;
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public void Delete(int Id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        targetService.Delete(Id);
    }
    #endregion
}
