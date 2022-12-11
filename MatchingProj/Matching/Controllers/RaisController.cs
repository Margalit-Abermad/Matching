using AppServices;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Matching.Controllers;

public class RaisController : BaseController
{
    IRaiseService raisService;

    public RaisController(IRaiseService raisService)
    {
        this.raisService = raisService;
    }

    Files f = new Files();

    #region HttpGet
    [HttpGet]
    public ActionResult<List<RaiseVM>> GetAll()
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var raisList = raisService.GetList();
        if (raisList.Count == 0)
        {
            return NoContent();
        }
        return Ok(raisList); 
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        raisService.Delete(id);
    }
    #endregion

    #region HttpGet
    [HttpGet("{id}")]
    public ActionResult<RaiseVM> GetById(int id)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        var rvm= raisService.GetById(id);
        if (rvm == null)
        {
            return NoContent();
        }
        return Ok(rvm);  
    }
    #endregion

    #region HttpPost
    [HttpPost] 
    public void Create(RaiseVM raisVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (raisVM != null)
        {
            raisService.Create(raisVM);
        }
        else
        {
            return;
        }
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public void Update(RaiseVM raiseVM)
    {
        string url = $"{Request.Scheme}://{Request.Host.Value}/{Request.Path}";
        f.Dofile(url);
        if (raiseVM != null)
        {
            raisService.Update(raiseVM);
        }
        return;
    }
    #endregion
}
