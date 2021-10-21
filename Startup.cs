using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SVPT.WebAPI.Helper;
using SVPT.WebAPI.Repository;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Services;
using SVPT.WebAPI.Services.Contracts;
using SVPT.WebAPI.Store.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();

            services.AddControllers(setup => 
            {
                setup.ReturnHttpNotAcceptable = true;
            });

            services.ConfigureSqlContext(Configuration);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IFileNameParseHelper, FileNameParseHelper>();

            //services.AddScoped<ISVTPTaskRepository, SVTPTaskRepository>();
            //services.AddScoped<ISVTPTaskItemRepository, SVTPTaskItemRepository>();
            //services.AddScoped<ISVTPTemplateItemRepository, SVTPTemplateItemRepository>();
            services.AddScoped<IDbRepositoryManager, DbRepositoryManager>();

            services.AddScoped<ISVTPTaskService, SVTPTaskService>();
            services.AddScoped<ITaskItemService, TaskItemService>();
            services.AddScoped<IExcelParseService, ExcelParseService>();
            services.AddScoped<ITestResultService, TestResultService>();

            //services.AddScoped<IApplicationDbContext, ISVTPDbContext>();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            services.AddTransient<IS3FileRepository, S3FileRepository>();
            services.AddTransient<ITransferUtility, TransferUtility>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
