using AutoMapper;
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
    [Route("api/task-item/{taskItemId}")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IMapper _mapper;

        public TaskItemController(ITaskItemService taskItemService, IMapper mapper)
        {
            _taskItemService = taskItemService ?? throw new ArgumentNullException(nameof(taskItemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<ActionResult<SVTPTaskReturnModel>> GetTaskItem(Guid taskItemId)
        {
            var svtpTask = await _taskItemService.GetTaskItemAsync(taskItemId);
            if (svtpTask == null)
            {
                return NotFound();
            }

            return Ok(svtpTask);
        }

        [HttpGet("results")]
        public async Task<ActionResult<IEnumerable<TaskItemTestResultReturnModel>>> GetTaskItemResults(Guid taskItemId)
        {
            var testResults = await _taskItemService.GetTestResultsAsync(taskItemId);
            if (testResults == null)
            {
                return NotFound();
            }

            return Ok(testResults);
        }
    }
}
