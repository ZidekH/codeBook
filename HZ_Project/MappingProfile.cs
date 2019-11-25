using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DTO_Models = HZ_Project.Models;
using EF_Models = EFDatabase.Models;

namespace HZ_Project
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<EF_Models.Player, DTO_Models.Player>();

            CreateMap<EF_Models.PersonalInformation, DTO_Models.PersonalInformation>();
            
            CreateMap< DTO_Models.Player,EF_Models.Player > ();

            CreateMap< DTO_Models.PersonalInformation,EF_Models.PersonalInformation > ();

            //CreateMap<IEnumerable<EF_Models.Player>, IEnumerable<DTO_Models.Player>>();

           
            //CreateMap<EF_Models.PersonalInformation, DTO_Models.PlayeDetailsViewModel>();
        }
    }
}
