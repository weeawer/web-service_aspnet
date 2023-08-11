using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ApiWebApplication.Models;

/// <summary>
/// Машина
/// </summary>
public class Car
{
	protected const int nameMinLength = 2; //минимальная длина названия
	protected const int nameMaxLength = 200; //максимальная длина названия

	public int Id { get; set; }

	[Required(ErrorMessage = "Обязательно должна быть введена марка машины")]
	[StringLength(nameMaxLength, MinimumLength = nameMinLength, ErrorMessage = "Длина марки машины должна быть не менее {2} и не более {1} символов")]
	[Comment("Марка машины")]
	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "Обязательно должен быть введен номер машины")]
	[StringLength(10, MinimumLength = 7, ErrorMessage = "Длина номера должна быть не менее {2} и не более {1} символов")]
	[Comment("Номер машины")]
	public string Number { get; set; } = null!;

	public int UserId { get; set; }
	public User? User { get; set; }
}
