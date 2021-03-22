using Back.Models;
using Back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Utils
{
    public class HelpClass
    {
        private  IRepositoryWrapper _repositoryWrapper;
        public HelpClass(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public  IQueryable GetDataFromDetais()
        {
            var data = from i in _repositoryWrapper.StoreKeeper.FindAll()
                       join c in _repositoryWrapper.Detail.FindAll() on i.Id equals c.storeKeeperId
                       select new Details { Id = c.Id, name = c.name, nunCode = c.nunCode, sum = c.sum, storeKepeerName = i.FullName, dateCreated = c.dateCreated, dateDeleted = c.dateDeleted };

            return data;
        }

        public IQueryable GetData()
        {

            var groupjoin = _repositoryWrapper.StoreKeeper.FindAll().Select(u => new
            {
                Id = u.Id,
                FullName = u.FullName,
                Count = _repositoryWrapper.Detail.FindAll().Where(s => s.storeKeeperId == u.Id).Sum(x => x.sum)
            });
            return groupjoin;
        }
    }
}
