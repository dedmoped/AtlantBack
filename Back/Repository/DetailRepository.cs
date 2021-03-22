﻿using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repository
{
    public class DetailRepository:RepositoryBase<Details>,IDetailRepository
    {
        public DetailRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
    }
}
