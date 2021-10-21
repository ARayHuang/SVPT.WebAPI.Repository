using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Store.Context
{
    public class SVTPDbContext : DbContext, IApplicationDbContext
    {
        public DbContext Instance => this;

        #region IApplicationDbContext Implement DbSet
        public DbSet<SVTPTask> tblSVTPTask { get; set; }
        public DbSet<TaskItem> tblTaskItem { get; set; }
        public DbSet<TaskItemTestResult> tblTaskItemTestResult { get; set; }
        public DbSet<TaskItemTestResultFile> tblTaskItemTestResultFile { get; set; }
        public DbSet<TaskNotifies> tblTaskNotifies { get; set; }
        public DbSet<SVTPTemplateItem> tblSVTPTemplateItem { get; set; }
        public DbSet<SVTPTemplate> tblSVTPTemplate { get; set; }
        #endregion

        public SVTPDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer("Data source=.; initial Catalog=SVPT;User ID=sa;Password=Passw0rd;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
