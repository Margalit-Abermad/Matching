using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Raises = new HashSet<Raise>();
        }

        public int Id { get; set; }
        public string PermissionsName { get; set; } = null!;
        public string PermissionsDetails { get; set; } = null!;
        public int? PermissionsPassword { get; set; }

        public virtual ICollection<Raise> Raises { get; set; }
    }
}
