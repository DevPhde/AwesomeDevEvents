﻿using AwesomeDevEvents.API.Entities;
using AwesomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.API.Controllers
{
	[Route("api/dev-events")]
	[ApiController]
	public class DevEventsController : ControllerBase
	{
		private DevEventsDbContext _context;

		public DevEventsController(DevEventsDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var devEvent = _context.DevEvents.Where(d => !d.isDeleted).ToList();
			return Ok(devEvent);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(Guid id)
		{
			var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
			if (devEvent == null)
			{
				return NotFound();
			}
			return Ok(devEvent);
		}
		[HttpPost]
		public IActionResult Post(DevEvent devEvent)
		{
			_context.DevEvents.Add(devEvent);
			return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, DevEvent input)
		{
			var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
			if (devEvent == null)
			{
				return NotFound();
			}
			devEvent.update(input.Title, input.Description, input.StartDate, input.EndDate);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);
			if (devEvent == null)
			{
				return NotFound();
			}
			devEvent.delete();
			return NoContent();
		}
	}
}