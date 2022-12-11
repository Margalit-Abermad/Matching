using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public interface IFundraisingGroupService
{
    List<FundraisingGroupVM> GetList();
    FundraisingGroupVM GetById(int id);
    void Delete(int id);
    void Update(FundraisingGroupVM fundraisingGroupVM);
    void Create(FundraisingGroupVM fundraisingGroupVM);  
}
