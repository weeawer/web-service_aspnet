using ApiWebApplication.Db;
using ApiWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
namespace ApiWebApplication.Controllers;

[Route("api/[controller]")]
public class CarsController : Controller
{
	public IRepository Repository { get; set; }
	public CarsController(IRepository repository)
	{
		Repository = repository;
	}

	/// <summary>
	/// Получить все зарегистрированные машины
	/// </summary>
	[HttpGet(Name = "GetAllCars")]
	public async Task<IEnumerable<Car>> GetAllCarsAsync()
	{
		var items = await Repository.GetAllCarsAsync();
		return items;
	}

	/// <summary>
	/// Получить информацию о машине по Id
	/// </summary>
	[HttpGet("{id}", Name = "GetCarById")]
	public async Task<IActionResult> GetCarByIdAsync(int id)
	{
		var item = await Repository.FindCarAsync(id);
		if (item == null)
		{
			return NotFound();
		}
		return new ObjectResult(item);
	}

	/// <summary>
	/// Создать/добавить новый автомобиль в БД 
	/// </summary>
	/// <param name="item">Добавляемый объект</param>
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Car item)
	{
		try
		{
			if (item == null)
			{
				return BadRequest();
			}
			await Repository.AddCarAsync(item);
			return CreatedAtRoute("GetCarById", new { id = item.Id }, item);
		}
		catch (Exception ex)
		{
			return BadRequest("Invalid input. " + ex.Message);
		}
		
	}


	/// <summary>
	/// Обновить информацию о машине
	/// </summary>
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] Car item)
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

		await Repository.UpdateCarAsync(item);
		return new NoContentResult();
	}


	/// <summary>
	/// Обновить информацию про автомобиль
	/// </summary>
	/// <param name="item">Новый объект</param>
	/// <param name="id">Id обновляемого объекта</param>
	/// <returns></returns>
	[HttpPatch("{id}")]
	public async Task<IActionResult> Update([FromBody] Car item, int id)
	{
		if (item == null)
		{
			return BadRequest();
		}

		var todo = await Repository.FindCarAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		item.Id = todo.Id;

		await Repository.UpdateCarAsync(item);
		return new NoContentResult();
	}

	/// <summary>
	/// Удалить машину
	/// </summary>
	/// <param name="id">Id удаляемой машины</param>
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var todo = await Repository.FindCarAsync(id);
		if (todo == null)
		{
			return NotFound();
		}

		await Repository.RemoveCarAsync(id);
		return new NoContentResult();
	}
}
