using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repository
{
   public interface IRepositoryWrapper
    {
        IDetailRepository Detail { get;}
        IStoreKeeperRepository StoreKeeper { get;}
        void Save();
    }
}
