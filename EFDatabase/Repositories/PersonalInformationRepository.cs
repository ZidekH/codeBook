using EFDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public class PersonalInformationRepository : CommonRepository<PersonalInformation>, IPersonalInformationRepository
    {
        public PersonalInformationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }

        public PersonalInformation GetInfoById_relatedData(int id)
        {
            //Todo: Not working with DBset Table here!!!!!!
           return table.Include(x => x.Player).Where(y => y.PersonalInformationId == id).FirstOrDefault();
        }
    }
}
