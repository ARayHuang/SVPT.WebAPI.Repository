using Microsoft.AspNetCore.Mvc;
using SVPT.WebAPI.Helper;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services.Contracts
{
    public interface ITestResultService
    {
        Task<TestResultValidationContainer> ValidateTestResultBeforeUploadAsync(string fileName, Stream stream);
        Task UploadTestResultAsync(TestResultValidationContainer validationContainer);
        Task UpdateTestResultScheuleAsync(Guid testResultId, DateTime startAt, DateTime endAt);
        Task UpdateTestResultWaivedOrBlockAsync(Guid testResultId, string status);
        Task DeleteTestResultAsync(Guid testResultId);
        Task<IEnumerable<TaskItemTestResultFileReturnModel>> GetTestResultFilesAsync(Guid testResultId);
        Task<DownloadTestResultFileResponse> DownloadTestResultFile(Guid fileId);
    }

    public class TestResultValidationContainer
    {
        public FileNameSplitContainer FileNameSplits { get; set; }
        public TaskItem Item { get; set; }
        public TaskItemTestResult TestResult { get; set; }
        public Stream UploadStream { get; set; }
    }

    public class DownloadTestResultFileResponse
    {
        public string Filename { get; set; }
        public string S3Key { get; set; }
        public Stream FileStream { get; set; }
    }
}
