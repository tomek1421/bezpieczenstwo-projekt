using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs;
using PersonApi.Entities;
using PersonApi.Extensions;
using PersonApi.Repository.Contracts;

namespace PersonApi.Controllers
{
	[ApiController]
	[Route("people")]
	public class PeopleController : ControllerBase
	{
		private readonly IPeopleRepository _repository;
		public PeopleController(IPeopleRepository repository) 
		{
			_repository = repository;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetAll()
		{
			var roles = User.GetApiClientRoles();

			if (roles is null) return Unauthorized();

			if (roles.Contains("admin"))
			{
				var result = await _repository.GetAll<PersonDto>();
				return result is null ? NotFound() : Ok(result);
			}

			if (roles.Contains("user"))
			{
				var result = await _repository.GetAll<PersonWithNoAgeDto>();
				return result is null ? NotFound() : Ok(result);
			}

			return Forbid();
		}

		[HttpGet("{id:int}")]
		[Authorize]
		public async Task<IActionResult> GetOne(int id) 
		{
			var roles = User.GetApiClientRoles();

			if (roles is null) return Unauthorized();

			// returned resource depends on user role
			if (roles.Contains("admin"))
			{
				Console.WriteLine("ADMIN");
				var result = await _repository.GetById<PersonDto>(id);
				return result is null ? NotFound() : Ok(result);
			}
			
			if (roles.Contains("user"))
			{
				Console.WriteLine("USER");
				var result = await _repository.GetById<PersonWithNoAgeDto>(id);
				return result is null ? NotFound() : Ok(result);
			}

			return Forbid();
			
			//return result switch
			//{
			//	null => NotFound(),
			//	_ => Ok(result)
			//};
			
		}

		[HttpPost]
		public async Task<IActionResult> Create(UpsertPersonDto body, IMapper mapper)
		{
			var person = mapper.Map<Person>(body);
			_repository.Add(person);
			if (!await _repository.SafeChangesAsync())
				return BadRequest("Something went wrong");

			var personDto = mapper.Map<PersonDto>(person);
			return CreatedAtAction(nameof(GetOne), new { id = person.Id }, personDto);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update(UpsertPersonDto body, IMapper mapper, int id)
		{
			var person = await _repository.GetById(id);
			if (person == null) 
				return NotFound();
			mapper.Map(body, person);
			_repository.Update(person);
			if (!await _repository.SafeChangesAsync())
				return BadRequest("Something went wrong");
			return NoContent();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var person = await _repository.GetById(id);
			if (person == null) 
				return NotFound();
			_repository.Delete(person);
			if (!await _repository.SafeChangesAsync())
				return BadRequest("Something went wrong");
			return NoContent();
		}
	}
}
