using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface IDbRepositoryManager
    {
        ISVTPTaskRepository SVTPTask { get; }
        ISVTPTaskItemRepository SVTPTaskItem { get; }
        ISVTPTaskItemTestResultRepository SVTPTaskItemTestResult { get; }
        ISVTPTaskItemTestResultFileRepository SVTPTaskItemTestResultFile { get; }
        ISVTPTemplateItemRepository SVTPTemplateItem { get; }
        Task SaveAsync();

    }
}
