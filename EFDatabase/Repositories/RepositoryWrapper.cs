using EFDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDatabase.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _applicationDbContext;
        private IPlayerRepository _player;
        private IMatchRepository _match;
        private IWeekendSessionRepository _weekendSession;
        private IPlayerWeekendStatisticsRepository _playerWeekendStatistics;
      

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IPlayerRepository Player
        {
            get { if(this._player == null)
                     this._player = new PlayerRepository(this._applicationDbContext);
                  return this._player;  
                }
        }

        public IMatchRepository Match
        {
            get
            {
                if (this._match == null)
                    this._match = new MatchRepository(this._applicationDbContext);
                return this._match;
            }
        }
        public IWeekendSessionRepository WeekendSession
        {
            get
            {
                if (this._weekendSession == null)
                    this._weekendSession = new WeekendSessionRepository(this._applicationDbContext);
                return this._weekendSession;
            }
        }

        public IPlayerWeekendStatisticsRepository PlayerWeekendStatistics
        {
            get
            {
                if (this._playerWeekendStatistics == null)
                    this._playerWeekendStatistics = new PlayerWeekendStatisticsRepository(this._applicationDbContext);
                return this._playerWeekendStatistics;
            }
        }

    }
}
