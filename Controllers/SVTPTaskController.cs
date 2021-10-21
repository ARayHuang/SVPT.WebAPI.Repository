using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Controllers
{
    [ApiController]
    [Route("api/svtp-task")]
    public class SVTPTaskController : ControllerBase
    {
        private readonly ISVTPTaskService _svtpTaskService;
        private readonly IMapper _mapper;

        public SVTPTaskController(ISVTPTaskService svtpTaskService, IMapper mapper)
        {
            _svtpTaskService = svtpTaskService ?? throw new ArgumentNullException(nameof(svtpTaskService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SVTPTaskReturnModel>>> GetSVTPTasks()
        {
            var svtpTasks = await _svtpTaskService.GetSVTPTasksAsync();
            if (svtpTasks == null)
            {
                return NotFound();
            }

            return Ok(svtpTasks);
        }

        [HttpGet("{svtpId}", Name = nameof(GetSVTPTasks))]
        public async Task<ActionResult<SVTPTaskReturnModel>> GetSVTPTask(Guid svtpId)
        {
            var svtpTask = await _svtpTaskService.GetSVTPTaskAsync(svtpId);
            if (svtpTask == null)
            {
                return NotFound();
            }

            return Ok(svtpTask);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<SVTPTaskReturnModel>>> CreateSVTPTask(SVTPTaskModel svtpTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svtpTaskReturnModels = await _svtpTaskService.AddSVTPTaskAsync(svtpTask);

            return CreatedAtRoute(nameof(GetSVTPTasks), new { SVTPId = svtpTaskReturnModels.Select(x => x.Id) }, svtpTaskReturnModels);
        }

        [HttpGet("{svtpId}/items", Name = nameof(GetTaskItems))]
        public async Task<ActionResult<IEnumerable<TaskItemReturnModel>>> GetTaskItems(Guid svtpId)
        {
            var svtpTasks = await _svtpTaskService.GetTaskItemsAsync(svtpId);

            return Ok(svtpTasks);
        }

        [HttpPost("{svtpId}/items", Name = nameof(GetTaskItems))]
        public async Task<ActionResult<IEnumerable<SVTPTaskReturnModel>>> AddTaskItems(Guid svtpId, TaskItemModel taskItem)
        {
            if (taskItem == null || taskItem.ItemIds == null)
            {
                return NotFound();
            }
            var svtpTask = await _svtpTaskService.AddTaskItemsAsync(svtpId, taskItem.ItemIds);

            return NoContent();
        }

        [HttpDelete("{svtpId}/items", Name = nameof(GetTaskItems))]
        public async Task<IActionResult> DeleteTaskItems(Guid svtpId, TaskItemModel taskItems)
        {
            if (taskItems == null || taskItems.ItemIds == null)
            {
                return NotFound();
            }
            await _svtpTaskService.DeleteTaskItems(svtpId, taskItems.ItemIds);

            return NoContent();
        }

        //[HttpPatch]
        //public async Task<ActionResult<SVTPTaskReturnModel>> UpdateSVTPTask(SVTPTaskModel svtpTask)
        //{
        //    var svtpTaskReturnModel = await _svtpTaskService.AddSVTPTaskAsync(svtpTask);

        //    return CreatedAtRoute(nameof(GetSVTPTasks), new { SVTPId = svtpTaskReturnModel.Id }, svtpTaskReturnModel);
        //}
    }
}
