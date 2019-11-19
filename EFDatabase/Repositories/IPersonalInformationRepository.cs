using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
   public interface IPersonalInformationRepository :ICommonRepository<PersonalInformation>
    {
        PersonalInformation GetInfoById_relatedData(int id);
    }
}
