using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public class SVTPTaskItemTestResultFileRepository : DbRepositoryBase<TaskItemTestResultFile>, ISVTPTaskItemTestResultFileRepository
    {
        public SVTPTaskItemTestResultFileRepository(SVTPDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<TaskItemTestResultFile>> GetTaskItemTestResultFilesAsync(Guid testResultId)
        {
            if (testResultId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await base.GetByConditionAsync(a => a.TaskItemTestResultId == testResultId);
        }

        public async Task<TaskItemTestResultFile> GetTaskItemTestResultFileAsync(Guid testResultFileId)
        {
            if (testResultFileId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await base.GetSingleByConditionAsync(x => x.Id == testResultFileId);
        }

        public void AddTaskItemTestResultFile(Guid taskItemTestResultId, TaskItemTestResultFile taskItemTestResultFile)
        {
            if (taskItemTestResultId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            if (taskItemTestResultFile == null)
            {
                throw new ArgumentNullException(nameof(taskItemTestResultFile));
            }

            taskItemTestResultFile.Id = Guid.NewGuid();
            taskItemTestResultFile.TaskItemTestResultId = taskItemTestResultId;

            taskItemTestResultFile.CreatedAt = DateTime.Now;
            taskItemTestResultFile.UpdatedAt = DateTime.Now;

            base.Create(taskItemTestResultFile);
        }

        public async Task<bool> IsTaskItemTestResultFileExistAsync(Guid testResultFileId)
        {
            if (testResultFileId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(testResultFileId));
            }

            return await base.IsEntityExistAsync(x => x.Id == testResultFileId);
        }
    }
}
