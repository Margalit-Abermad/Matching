using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class PermissionsRepository : IPermissionsRepository
{

    MatchingContext context;

    public PermissionsRepository(MatchingContext context)
    {
        this.context = context;
    }


    //function that return true if the password is matima to the permission man,
    //and return false if not.
    public bool EqualsPassword(int password, int PermissionsID)
    {
        var x = context.Permissions.FirstOrDefault(x => x.Id == PermissionsID);
        if (x != null)
        {
            if (x.PermissionsPassword == password)
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public string GetPermissionsDetails(int id)
    { 
            var permissionsID = context.Permissions.FirstOrDefault(x => x.Id == id);
            if (permissionsID != null)
            {
                return $"your permissions: {permissionsID.PermissionsDetails}";
            }
            return null;
        }
    }

