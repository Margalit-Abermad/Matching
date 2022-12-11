using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public class TargetsVM
{
    public float TargetSum { get; set; }

    public int FundraisingID { get; set; } 

    public float Collected { get; set; }

    public float MissingTrget { get; set; }

    public DateTime Deadline { get; set; }
}
