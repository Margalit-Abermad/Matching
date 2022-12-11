using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Target
    {
        public Target()
        {
            FundraisingGroups = new HashSet<FundraisingGroup>();
        }

        public int TargetId { get; set; }
        public double TargetSum { get; set; }
        public int FundraisingId { get; set; }
        public double Collected { get; set; }
        public double MissingTrget { get; set; }
        public DateTime Deadline { get; set; }

        public virtual ICollection<FundraisingGroup> FundraisingGroups { get; set; }
    }
}
