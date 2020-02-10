using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class EducationModuleRepository : BaseRepository<EducationModule, HCRGUniversityDBContext>, IEducationModuleRepository
    {
        public EducationModuleRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public int AddEducationModule(EducationModule educationModule)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationModule.EducationID);
            SqlParameter _educationModuleName = new SqlParameter("@EducationModuleName", educationModule.EducationModuleName);
            SqlParameter _educationModuleTime;
            if (educationModule.EducationModuleTime == null)
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", DBNull.Value);
            }           
            else
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", educationModule.EducationModuleTime);
            }           
            SqlParameter _educationModuleDate = new SqlParameter("@EducationModuleDate", educationModule.EducationModuleDate);
            SqlParameter _educationModulePosition = new SqlParameter("@EducationModulePosition", educationModule.EducationModulePosition);
            SqlParameter _educationModuleDescription = new SqlParameter("@EducationModuleDescription", educationModule.EducationModuleDescription);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.AddEducationModule, _educationID, _educationModuleName,_educationModuleDescription, _educationModuleTime, _educationModuleDate, _educationModulePosition).Single();
        }
        public int UpdateEducationModule(EducationModule educationModule)
        {
            SqlParameter _educationModuleID = new SqlParameter("@EducationModuleID", educationModule.EducationModuleID);
            SqlParameter _educationID = new SqlParameter("@EducationID", educationModule.EducationID);
            SqlParameter _educationModuleName = new SqlParameter("@EducationModuleName", educationModule.EducationModuleName);
            SqlParameter _educationModuleTime;
            if (educationModule.EducationModuleTime == null)
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", DBNull.Value);
            }
            else
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", educationModule.EducationModuleTime);
            }   
            SqlParameter _educationModuleDate = new SqlParameter("@EducationModuleDate", educationModule.EducationModuleDate);
            SqlParameter _educationModulePosition = new SqlParameter("@EducationModulePosition", educationModule.EducationModulePosition);
            SqlParameter _educationModuleDescription = new SqlParameter("@EducationModuleDescription", educationModule.EducationModuleDescription);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.UpdateEducationModule, _educationModuleID, _educationID, _educationModuleName,_educationModuleDescription, _educationModuleTime, _educationModuleDate, _educationModulePosition).Single();
        }

        public int UpdateEducationModuleTime(EducationModule educationModule)
        {
            SqlParameter _educationModuleID = new SqlParameter("@EducationModuleID", educationModule.EducationModuleID);

            SqlParameter _educationModuleTime;
            if (educationModule.EducationModuleTime == null)
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", DBNull.Value);
            }
            else
            {
                _educationModuleTime = new SqlParameter("@EducationModuleTime", educationModule.EducationModuleTime);
            }  
         //   SqlParameter _educationModuleTime = new SqlParameter("@EducationModuleTime", educationModule.EducationModuleTime);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.UpdateEducationModuleTime, _educationModuleID, _educationModuleTime).Single();
        }

        public void DeleteEducationModule(int educationModuleID)
        {
            SqlParameter _educationModuleID = new SqlParameter("@EducationModuleID", educationModuleID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.DeleteEducationModule, _educationModuleID);
     

        }

        public IEnumerable<EducationModule> GetAllPagedEducationModuleByEid(int eid, int skip, int take)
        {
            SqlParameter _Eid = new SqlParameter("@EducationId", eid);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<EducationModule>(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.GetAllPagedEducationModuleByEid, _Eid, _skip, _take);
        }

        public int GetEducationModuleCountByeid(System.Linq.Expressions.Expression<Func<EducationModule, bool>> where)
        {
            return dbset.Where(where).Count();
        }

        public Client GetOrganizationClientByEducationModuleID(int educationModuleID)
        {
            SqlParameter _educationModuleID = new SqlParameter("@EducationModuleID", educationModuleID);
            return Context.Database.SqlQuery<Client>(Constant.StoredProcedureConst.EducationModuleRepositoryProcedure.GetOrganizationClientByEducationModuleID, _educationModuleID).SingleOrDefault();
        }

    }
}
