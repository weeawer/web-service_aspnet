using ApiWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWebApplication.Db;

public class Repository : IRepository
{
	private readonly IDbContextFactory<MyAppDbContext> _contextFactory;

	public Repository(IDbContextFactory<MyAppDbContext> contextFactory)
	{
		_contextFactory = contextFactory;
	}

	#region ------------ Users ------------ 
	public async Task AddUserAsync(User item)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			db.Users.Add(item);
			await db.SaveChangesAsync();
		}
	}

	public async Task<User?> FindUserAsync(int id)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
			return user;
		}
	}

	public async Task<IEnumerable<User>> GetAllUsersAsync()
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			await db.Users.LoadAsync();
			return db.Users.ToList();
		}
	}


	public async Task<IEnumerable<Car>> GetUserAllCarsAsync(int userId)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var cars = await db.Cars.Where(x=>x.UserId == userId).ToListAsync();
			return cars;
		}
	}


	public async Task UpdateUserAsync(User item)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var user = db.Users.Update(item);
			await db.SaveChangesAsync();
		}
	}

	public async Task<User?> RemoveUserAsync(int id)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (user != null)
			{
				db.Users.Remove(user);
				await db.SaveChangesAsync();
			}
			return user;
		}
	}
	#endregion

	#region ------------ Cars ------------ 
	public async Task AddCarAsync(Car item)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			db.Cars.Add(item);
			await db.SaveChangesAsync();
		}
	}

	public async Task<Car?> FindCarAsync(int id)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);
			return car;
		}
	}

	public async Task<IEnumerable<Car>> GetAllCarsAsync()
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			await db.Cars.LoadAsync();
			return db.Cars.ToList();
		}
	}

	public async Task UpdateCarAsync(Car item)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var user = db.Cars.Update(item);
			await db.SaveChangesAsync();
		}
	}

	public async Task<Car?> RemoveCarAsync(int id)
	{
		using (var db = _contextFactory.CreateDbContext())
		{
			var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);
			if (car != null)
			{
				db.Cars.Remove(car);
				await db.SaveChangesAsync();
			}
			return car;
		}
	}
	#endregion
}
