using ApiWebApplication.Db;
using ApiWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace ApiWebApplication.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
	public IRepository Repository { get; set; }
	public UsersController(IRepository repository)
	{
		Repository = repository;
	}

	/// <summary>
	/// Выдать всех зарегистрированных автовладельцев
	/// </summary>
	[HttpGet(Name = "GetUsers")]
	public async Task<IEnumerable<User>> GetAllUsersAsync()
	{
			var users = await Repository.GetAllUsersAsync();
			return users;
	}

	/// <summary>
	/// Получить информацию о владжельце по Id
	/// </summary>
	[HttpGet("{id}", Name = "GetUser")]
	public async Task<IActionResult> GetUserByIdAsync(int id)
	{
		var item = await Repository.FindUserAsync(id);
		if (item == null)
		{
			return NotFound();
		}
		return new ObjectResult(item);
	}


	/// <summary>
	/// Получить информацию о всех автомобилях владжельца по Id
	/// </summary>
	[HttpGet("cars/{id}")]
	public async Task<IEnumerable<Car>> GetUserCarsByUserIdAsync(int id)
	{
		var cars = await Repository.GetUserAllCarsAsync(id);
		return cars;
	}


	/// <summary>
	/// Создать/добавить нового автовладельца в БД 
	/// </summary>
	/// <param name="item">Добавляемый объект</param>
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] User item)
	{
		try
		{
			if (item == null)
			{
				return BadRequest();
			}
			await Repository.AddUserAsync(item);
			return CreatedAtRoute("GetUser", new { id = item.Id }, item);
		}
		catch (Exception ex)
		{
			return BadRequest("Invalid input. " + ex.Message);
		}
		
	}

	/// <summary>
	/// Обновить информацию об объекте
	/// </summary>
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] User item)
	{
		if (item == null || item.Id != id)
		{
			return BadRequest();
		}

		var todo = await Repository.FindUserAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		await Repository.UpdateUserAsync(item);
		return new NoContentResult();
	}

	/// <summary>
	/// Обновить оъект
	/// </summary>
	/// <param name="item">Новый объект</param>
	/// <param name="id">Id обновляемого объекта</param>
	/// <returns></returns>
	[HttpPatch("{id}")]
	public async Task<IActionResult> Update([FromBody] User item, int id)
	{
		if (item == null || item.Id != id)
		{
			return BadRequest();
		}

		var todo =await Repository.FindUserAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		item.Id = todo.Id;

		await Repository.UpdateUserAsync(item);
		return new NoContentResult();
	}

	/// <summary>
	/// Удалить объект
	/// </summary>
	/// <param name="id">Id удаляемого объекта</param>
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var todo =await Repository.FindUserAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		await Repository.RemoveUserAsync(id);
		return new NoContentResult();
	}
}
