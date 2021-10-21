using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Store.Entity;
using System;

namespace SVPT.WebAPI.Store.Context
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
    }

    public interface IApplicationDbContext : IDbContext
    {
        DbSet<SVTPTask> tblSVTPTask { get; set; }
        DbSet<TaskItem> tblTaskItem { get; set; }
        DbSet<TaskItemTestResult> tblTaskItemTestResult { get; set; }
        DbSet<TaskItemTestResultFile> tblTaskItemTestResultFile { get; set; }
        DbSet<TaskNotifies> tblTaskNotifies { get; set; }
        DbSet<SVTPTemplateItem> tblSVTPTemplateItem { get; set; }
        DbSet<SVTPTemplate> tblSVTPTemplate { get; set; }
    }
}
