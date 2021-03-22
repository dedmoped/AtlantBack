using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repository
{
    public class StoreKeeperRepository:RepositoryBase<StoreKeeper>,IStoreKeeperRepository
    {
        public StoreKeeperRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
                
        }
    }
}
