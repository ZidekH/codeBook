using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Models
{
    interface ITrackingEntity
    {
        DateTime Created { get; set; }
        int CreatedBy { get; set; }
        DateTime? Updated { get; set; }
        int? UpdatedBy { get; set; }
    }
}
