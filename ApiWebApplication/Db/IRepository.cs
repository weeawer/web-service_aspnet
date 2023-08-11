using ApiWebApplication.Models;
namespace ApiWebApplication.Db;

public interface IRepository
{
	#region ------------ Users ------------ 
	
	/// <summary>
	/// Добавить владельца в БД
	/// </summary>
	/// <param name="item">Добавляемый владелец</param>
	public Task AddUserAsync(User item);

	/// <summary>
	/// Получить всех владельцев
	/// </summary>
	/// <returns></returns>
	//public IEnumerable<User> GetAllUsers();
	public Task<IEnumerable<User>> GetAllUsersAsync();

	/// <summary>
	/// Найти владельца
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task<User?> FindUserAsync(int id);

	/// <summary>
	/// Получить все машины у владельца
	/// </summary>
	public Task<IEnumerable<Car>> GetUserAllCarsAsync(int userId);

	/// <summary>
	/// Обновить владельца
	/// </summary>
	/// <param name="item"></param>
	public Task UpdateUserAsync(User item);

	/// <summary>
	/// Удалить владельца
	/// </summary>
	public Task<User?> RemoveUserAsync(int id);
	#endregion

	#region ------------ Cars ------------ 

	/// <summary>
	/// Добавить машину в БД
	/// </summary>
	public Task AddCarAsync(Car item);

	/// <summary>
	/// Получить все машины
	/// </summary>
	public Task<IEnumerable<Car>> GetAllCarsAsync();

	/// <summary>
	/// Найти машину 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Task<Car?> FindCarAsync(int id);

	/// <summary>
	/// Обновить информацию по машине
	/// </summary>
	/// <param name="item"></param>
	public Task UpdateCarAsync(Car item);

	/// <summary>
	/// Удалить информацию о машине
	/// </summary>
	public Task<Car?> RemoveCarAsync(int id);
	#endregion
}
