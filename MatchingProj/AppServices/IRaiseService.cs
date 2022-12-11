using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public interface IRaiseService
{
    List<RaiseVM> GetList();

    RaiseVM GetById(int Id);

    void Delete(int Id);

    void Update(RaiseVM raiseVM);    
    
    void Create(RaiseVM raiseVM);

}
