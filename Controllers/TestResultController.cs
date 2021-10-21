using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Controllers
{
    [ApiController]
    [Route("api/test-result")]
    public class TestResultController : ControllerBase
    {
        private readonly ITestResultService _testResultService;

        public TestResultController(ITestResultService testResultService)
        {
            _testResultService = testResultService ?? throw new ArgumentNullException(nameof(testResultService));
        }

        [HttpPost()]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadTestResult([FromForm] IList<IFormFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    using (var newMemoryStream = new MemoryStream())
                    {
                        file.CopyTo(newMemoryStream);
                        var fileSplitContainer = await _testResultService.ValidateTestResultBeforeUploadAsync(file.FileName, newMemoryStream);
                        await _testResultService.UploadTestResultAsync(fileSplitContainer);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPatch("{testResultId}/schedule")]
        public async Task<IActionResult> UpdateTestResultSchedule(Guid testResultId, TestResultUpdateScheduleModel updateScheduleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _testResultService.UpdateTestResultScheuleAsync(testResultId, updateScheduleModel.StartAt, updateScheduleModel.EndAt);

            return NoContent();
        }

        [HttpPatch("{testResultId}/waivedorblock")]
        public async Task<IActionResult> UpdateTestResultWaiveOrBlock(Guid testResultId, TestResultUpdateWaivedOrBlockModel updateWaivedOrBlockModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _testResultService.UpdateTestResultWaivedOrBlockAsync(testResultId, updateWaivedOrBlockModel.WaiveOrBlock);

            return NoContent();
        }

        [HttpDelete("{testResultId}")]
        public async Task<IActionResult> DeleteTestResult(Guid testResultId)
        {
            if (testResultId != null && testResultId == Guid.Empty)
            {
                return BadRequest(testResultId);
            }

            await _testResultService.DeleteTestResultAsync(testResultId);

            return NoContent();
        }

        [HttpGet("{testResultId}/files", Name = nameof(GetTaskItemResultFiles))]
        public async Task<ActionResult<IEnumerable<TaskItemTestResultReturnModel>>> GetTaskItemResultFiles(Guid testResultId)
        {
            if (testResultId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(testResultId));
            }

            var testResulFiles = await _testResultService.GetTestResultFilesAsync(testResultId);

            return Ok(testResulFiles);
        }

        [HttpGet("{testResultId}/file/{fileId}", Name = nameof(DownliadTestResult))]
        public async Task<FileStreamResult> DownliadTestResult(Guid fileId)
        {
            var response = await _testResultService.DownloadTestResultFile(fileId);

            return new FileStreamResult(response.FileStream, "application/octet-stream") { FileDownloadName = response.Filename };
        }
    }
}
