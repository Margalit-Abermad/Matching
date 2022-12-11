using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public interface IPermissionsRepository
{
    public bool EqualsPassword(int password, int PermissionsID); //password need be string or int?
    public string GetPermissionsDetails(int id);
}
