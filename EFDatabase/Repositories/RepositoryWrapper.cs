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
        private IPersonalInformationRepository _personalInformation;

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

        public IPersonalInformationRepository PersonalInformation
        {
            get
            {
                if (this._personalInformation == null)
                    this._personalInformation = new PersonalInformationRepository(this._applicationDbContext);
                return this._personalInformation;
            }
        }

    }
}
