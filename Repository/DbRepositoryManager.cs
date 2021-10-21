using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Store.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public class DbRepositoryManager : IDbRepositoryManager
    {
        private SVTPDbContext _dbContext;
        private ISVTPTaskRepository _svtpTaskRepository;
        private ISVTPTaskItemRepository _svtpTaskItemRepository;
        private ISVTPTaskItemTestResultRepository _svtpTaskItemTestResultRepository;
        private ISVTPTaskItemTestResultFileRepository __svtpTaskItemTestResultFileRepository;
        private ISVTPTemplateItemRepository _svtpTemplateItemRepository;
        public DbRepositoryManager(SVTPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ISVTPTaskRepository SVTPTask
        {
            get
            {
                if (_svtpTaskRepository == null)
                    _svtpTaskRepository = new SVTPTaskRepository(_dbContext);

                return _svtpTaskRepository;
            }
        }
        public ISVTPTaskItemRepository SVTPTaskItem
        {
            get
            {
                if (_svtpTaskItemRepository == null)
                    _svtpTaskItemRepository = new SVTPTaskItemRepository(_dbContext);

                return _svtpTaskItemRepository;
            }
        }
        public ISVTPTaskItemTestResultRepository SVTPTaskItemTestResult
        {
            get
            {
                if (_svtpTaskItemTestResultRepository == null)
                    _svtpTaskItemTestResultRepository = new SVTPTaskItemTestResultRepository(_dbContext);

                return _svtpTaskItemTestResultRepository;
            }
        }
        public ISVTPTaskItemTestResultFileRepository SVTPTaskItemTestResultFile
        {
            get
            {
                if (__svtpTaskItemTestResultFileRepository == null)
                    __svtpTaskItemTestResultFileRepository = new SVTPTaskItemTestResultFileRepository(_dbContext);

                return __svtpTaskItemTestResultFileRepository;
            }
        }
        public ISVTPTemplateItemRepository SVTPTemplateItem
        {
            get
            {
                if (_svtpTemplateItemRepository == null)
                    _svtpTemplateItemRepository = new SVTPTemplateItemRepository(_dbContext);

                return _svtpTemplateItemRepository;
            }
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
