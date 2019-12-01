using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models.ViewModels
{
    public class MatchProgress
    {
        public int PlayerId { get; set; }
        public GoalAction Goal { get; set; }
            public enum GoalAction
            {
            Add,
            Remove
            }
    }
}
