using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface ISVTPTaskItemTestResultFileRepository
    {
        Task<IEnumerable<TaskItemTestResultFile>> GetTaskItemTestResultFilesAsync(Guid testResultId);
        Task<TaskItemTestResultFile> GetTaskItemTestResultFileAsync(Guid testResultFileId);
        void AddTaskItemTestResultFile(Guid taskItemTestResultId, TaskItemTestResultFile taskItemTestResultFile);
        Task<bool> IsTaskItemTestResultFileExistAsync(Guid testResultFileId);
    }
}
