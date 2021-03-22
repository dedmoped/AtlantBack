using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        private RepositoryContext _repoContext;
        private IDetailRepository _detail;
        private IStoreKeeperRepository _storeKeeperRepository;
        public IDetailRepository Detail
        {
            get
            {
                if (_detail == null)
                {
                    _detail = new DetailRepository(_repoContext);
                }
                return _detail;
            }
        }
        public IStoreKeeperRepository StoreKeeper
        {
            get
            {
                if (_storeKeeperRepository == null)
                {
                    _storeKeeperRepository = new StoreKeeperRepository(_repoContext);
                }
                return _storeKeeperRepository;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }
}
