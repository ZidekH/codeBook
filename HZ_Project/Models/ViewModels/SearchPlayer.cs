using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HZ_Project.Models.ViewModels
{
    public class SearchPlayer
    {
        public string SearchText { get; set; }
        public List<PersonalInformation> ListOfPersonalInformation { get; set; }

    }
}
