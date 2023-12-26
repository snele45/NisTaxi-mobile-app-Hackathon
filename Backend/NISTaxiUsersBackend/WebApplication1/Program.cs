using Microsoft.EntityFrameworkCore;
using WebApplication1.Authentication;
using WebApplication1.DatabaseContext;
using WebApplication1.Repository;
using WebApplication1.RepositoryInterfaces;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			builder.Services.AddScoped<IDriverRepository, DriverRepository>();

			builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
			builder.Services.AddScoped<Authentication.IAuthenticationService, Authentication.AuthenticationService>();
			builder.Services.AddScoped<IJwtProvider, JwtProvider>();

			builder.Services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services
			.AddCors(options =>
			{
				options.AddPolicy("AllowOrigin",
					builder => builder.WithOrigins("*")
									  .AllowAnyHeader()
									  .AllowAnyOrigin()
									  .AllowAnyMethod());
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("AllowOrigin");


			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
