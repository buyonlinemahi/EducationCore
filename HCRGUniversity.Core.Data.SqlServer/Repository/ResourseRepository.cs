﻿using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
   
    public class  ResourseRepository : BaseRepository<Resource, HCRGUniversityDBContext>, IResourceRepository
    {
        public ResourseRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
    }
}
