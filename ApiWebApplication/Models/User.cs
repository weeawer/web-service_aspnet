using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ApiWebApplication.Models;

/// <summary>
/// Владелец машины
/// </summary>
public class User
{
	protected const int nameMinLength = 2; //минимальная длина ФИО
	protected const int nameMaxLength = 120; //максимальная длина ФИО

	[Key]
	public int Id { get; set; }

	/// <summary>
	/// ФИО
	/// </summary>
	[Required(ErrorMessage = "Обязательно должно быть введен ФИО")]
	[StringLength(nameMaxLength, MinimumLength = nameMinLength, ErrorMessage = "Длина ФИО должна быть не менее {2} и не более {1} символов")]
	[Comment("ФИО")]
	public string FIO { get; set; } = null!;
	
	/// <summary>
	/// Возраст
	/// </summary>
	[Range(16, int.MaxValue, ErrorMessage = "Значение возраста должно быть в диапазоне от {1} до {2}")]
	public int Age { get; set; }

	/// <summary>
	/// Пол человека
	/// </summary>
	[Required(ErrorMessage = "Обязательно должен быть введен пол")]
	[StringLength(7, MinimumLength = 3, ErrorMessage = "Длина пола должна быть не менее {2} и не более {1} символов")]
	[Comment("Пол")]
	public string Gender { get; set; } = null!;

	/// <summary>
	/// НОмер прав
	/// </summary>
	[Required(ErrorMessage = "Обязательно должен быть введен номер прав")]
	[StringLength(12, MinimumLength = 3, ErrorMessage = "Длина номера прав должна быть не менее {2} и не более {1} символов")]
	[Comment("Номер прав")]
	public string Number { get; set; } = null!;
}
