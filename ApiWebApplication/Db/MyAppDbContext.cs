using ApiWebApplication.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ApiWebApplication.Db;

public class MyAppDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Car> Cars{ get; set; }

	public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	//public MyAppDbContext()
	//{
	//	//Database.EnsureDeleted();
	//	//Database.EnsureCreated();
	//}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{

		//optionsBuilder.UseSqlServer("Data Source=WIN10PC;Initial Catalog=UsersCars;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
	}
}