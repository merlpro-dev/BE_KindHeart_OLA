﻿using Microsoft.AspNetCore.Mvc;
using Online_Learning_APP.Application.DTO;
using Online_Learning_APP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Learning_App_Presentation.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivity([FromBody] CreateActivityDto createActivityDto)
        {
            var activityDto = await _activityService.CreateActivityAsync(createActivityDto);
            return CreatedAtAction(nameof(GetActivityById), new { id = activityDto.ActivityId }, activityDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivityById(Guid id)
        {
            var activityDto = await _activityService.GetActivityByIdAsync(id);
            if (activityDto == null)
            {
                return NotFound(new { message = "Activity not found" });
            }
            return Ok(activityDto);
        }

        [HttpGet("activitieslist")]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAllActivities()
        {
            var activities = await _activityService.GetAllActivitiesAsync();
            return Ok(activities);
        }

      
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityDto>> UpdateActivity(Guid id, [FromBody] UpdateActivityDto updateActivityDto)
        {
            var updatedActivity = await _activityService.UpdateActivityAsync(id, updateActivityDto);
            if (updatedActivity == null)
            {
                return NotFound(new { message = "Activity not found" });
            }
            return Ok(updatedActivity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            var deleted = await _activityService.DeleteActivityAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Activity not found" });
            }
            return NoContent(); // 204 - Successfully deleted
        }
    }
}
