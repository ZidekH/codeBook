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
                    
            CreateMap< DTO_Models.Player,EF_Models.Player > ();

            //WeekendSession
            CreateMap<DTO_Models.Match, EF_Models.Match>();

            CreateMap<EF_Models.Match, DTO_Models.Match>();

            CreateMap<DTO_Models.Team, EF_Models.Team>();

            CreateMap<EF_Models.Team, DTO_Models.Team>();

            CreateMap<DTO_Models.PlayerWeekendStatistic, EF_Models.PlayerWeekendStatistic>();

            CreateMap<EF_Models.PlayerWeekendStatistic, DTO_Models.PlayerWeekendStatistic>();

        }
    }
}
