using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public interface IpermissionsService
{
    public bool EqualsPassword(int password, int PermissionsID);

    public string GetPermissionsDetails(int permissionsID);
}
