using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SVPT.WebAPI.Constant;
using SVPT.WebAPI.Helper;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Services.Contracts;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly IDbRepositoryManager _repositoryManager;
        private readonly IS3FileRepository _fileRepository;
        private readonly IExcelParseService _excelParseService;
        private readonly IMapper _mapper;
        private readonly IFileNameParseHelper _fileNameParseHelper;

        public TestResultService(
            IDbRepositoryManager repositoryManager,
            IS3FileRepository fileRepository,
            IExcelParseService excelParseService,
            IMapper mapper,
            IFileNameParseHelper fileNameParseHelper
            )
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _excelParseService = excelParseService ?? throw new ArgumentNullException(nameof(excelParseService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _fileNameParseHelper = fileNameParseHelper ?? throw new ArgumentNullException(nameof(fileNameParseHelper));
        }

        public async Task<TestResultValidationContainer> ValidateTestResultBeforeUploadAsync(string fileName, Stream stream)
        {
            var fileNameSplitContainer = _fileNameParseHelper.ParseFilename(fileName);
            if (fileNameSplitContainer == null)
            {
                throw new ArgumentNullException(nameof(fileNameSplitContainer));
            }

            var matchItem = await _repositoryManager.SVTPTaskItem.GetTaskItemAsync(
                                                        fileNameSplitContainer.Version,
                                                        fileNameSplitContainer.Project,
                                                        fileNameSplitContainer.Phase,
                                                        fileNameSplitContainer.Item,
                                                        fileNameSplitContainer.SubItem);

            if (matchItem == null)
            {
                throw new ArgumentNullException(nameof(matchItem));
            }


            var matchItemTestResult = await _repositoryManager.SVTPTaskItemTestResult.GetTaskItemTestResultAsync(
                                                                            matchItem.Id,
                                                                            fileNameSplitContainer.Information,
                                                                            fileNameSplitContainer.Vendor,
                                                                            fileNameSplitContainer.ExtraKey);

            _excelParseService.CreateExcelPackage(stream);
            fileNameSplitContainer.TestResult = _excelParseService.GetTestResultStatus();

            //TODO: sku or modules or devices ...other key validation

            fileNameSplitContainer.S3UploadPath = string.Format("{0}/{1}", fileNameSplitContainer.S3UploadPath, fileNameSplitContainer.FullName);

            return new TestResultValidationContainer
            {
                FileNameSplits = fileNameSplitContainer,
                Item = matchItem,
                TestResult = matchItemTestResult,
                UploadStream = stream
            };
        }

        public async Task UploadTestResultAsync(TestResultValidationContainer validationContainer)
        {
            var matchItem = validationContainer.Item;
            var matchItemTestResult = validationContainer.TestResult;
            var fileNameSplits = validationContainer.FileNameSplits;
            var stream = validationContainer.UploadStream;

            if (matchItemTestResult == null)
            {
                matchItemTestResult = await AddTestResult(matchItem.Id, fileNameSplits);
                Console.WriteLine(string.Format("matchItemTestResultId: {0} ", matchItemTestResult.Id.ToString()));
            }

            await AddTestResultFile(matchItemTestResult.Id, fileNameSplits);

            await _fileRepository.UploadFile(stream, fileNameSplits.S3UploadPath);
        }

        public async Task UpdateTestResultScheuleAsync(Guid testResultId, DateTime startAt, DateTime endAt)
        {
            var testResult = await _repositoryManager.SVTPTaskItemTestResult.GetTaskItemTestResultAsync(testResultId);
            if (testResult == null)
            {
                throw new ArgumentNullException(nameof(testResultId));
            }

            testResult.StartAt = startAt;
            testResult.EndAt = endAt;

            _repositoryManager.SVTPTaskItemTestResult.UpdateTaskItemTestResult(testResult);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateTestResultWaivedOrBlockAsync(Guid testResultId, string status)
        {
            var testResult = await _repositoryManager.SVTPTaskItemTestResult.GetTaskItemTestResultAsync(testResultId);
            if (testResult == null)
            {
                throw new ArgumentNullException(nameof(testResultId));
            }

            testResult.WaiveOrBlock = status;

            _repositoryManager.SVTPTaskItemTestResult.UpdateTaskItemTestResult(testResult);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteTestResultAsync(Guid testResultId)
        {
            await _repositoryManager.SVTPTaskItemTestResult.DeleteTaskItemTestResult(testResultId);

            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<TaskItemTestResultFileReturnModel>> GetTestResultFilesAsync(Guid testResultId)
        {
            var taskItemTestResultFiles = await _repositoryManager.SVTPTaskItemTestResultFile.GetTaskItemTestResultFilesAsync(testResultId);

            return _mapper.Map<IEnumerable<TaskItemTestResultFileReturnModel>>(taskItemTestResultFiles);
        }

        public async Task<DownloadTestResultFileResponse> DownloadTestResultFile(Guid fileId)
        {
            var downloadFile = await _repositoryManager.SVTPTaskItemTestResultFile.GetTaskItemTestResultFileAsync(fileId);
            if (downloadFile == null)
            {
                return null;
            }

            var returnStream = await _fileRepository.DownloadFile(downloadFile.S3FileAccessKey);

            return new DownloadTestResultFileResponse
            {
                Filename = downloadFile.FileName,
                S3Key = downloadFile.S3FileAccessKey,
                FileStream = returnStream
            };
        }

        private async Task<TaskItemTestResult> AddTestResult(Guid taskItemId, FileNameSplitContainer container)
        {
            var taskItemTestResult = new TaskItemTestResult
            {
                Id = Guid.NewGuid(),
                Item = container.Information,
                Vendor = container.Vendor,
                Status = (ResultStatus)Enum.Parse(typeof(ResultStatus), container.TestResult, true),
                ExtraKey = container.ExtraKey,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _repositoryManager.SVTPTaskItemTestResult.AddTaskItemTestResult(taskItemId, taskItemTestResult);
            await _repositoryManager.SaveAsync();

            return taskItemTestResult;
        }

        private async Task AddTestResultFile(Guid taskItemTestResultId, FileNameSplitContainer container)
        {
            var taskItemTestResult = new TaskItemTestResultFile
            {
                Id = Guid.NewGuid(),
                FileName = container.FullName,
                S3FileAccessKey = container.S3UploadPath,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _repositoryManager.SVTPTaskItemTestResultFile.AddTaskItemTestResultFile(taskItemTestResultId, taskItemTestResult);

            Console.WriteLine(string.Format("taskItemTestResult: {0} ", taskItemTestResult.Id.ToString()));
            await _repositoryManager.SaveAsync();
        }

    }
}
