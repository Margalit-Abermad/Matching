using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public class PermissionsService : IpermissionsService
{

    IPermissionsRepository repo;
    public PermissionsService(IPermissionsRepository repo)
    {
        this.repo = repo;
    }

    //return true if the password is right!
    public bool EqualsPassword(int password, int PermissionsID)
    {
        bool equalsPassword= repo.EqualsPassword(password, PermissionsID);
        if (equalsPassword)
        {
            return true;
        }
        return false;
    }


    //return the permission details.
    public string GetPermissionsDetails(int permissionsID)
    {
       return repo.GetPermissionsDetails(permissionsID);
    }
}
